using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class PlayerMotor : MonoBehaviour
{
    Transform target;
    NavMeshAgent agent;
    [SerializeField] private GameObject clickEffect;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        if (target != null)
        {
            agent.SetDestination(target.position);
            FaceTarget();
        }
    }

    public void MoveToPoint(Vector3 point)
    {
        agent.SetDestination(point);

        if (clickEffect != null)
        {
            clickEffect.transform.position = point += new Vector3(0, 0.1f, 0);
            clickEffect.GetComponent<ParticleSystem>().Play();

        }
    }

    public void FollowTarget(Interactable newTarget)
    {
        agent.stoppingDistance = newTarget.radius * 0.8f;
        agent.updateRotation = false;

        target = newTarget.interactionTransform;
    }
    public void StopFollowingTarget()
    {
        agent.stoppingDistance = 0;
        agent.updateRotation = true;
        target = null;
    }

    void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x,0f,direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }
}
