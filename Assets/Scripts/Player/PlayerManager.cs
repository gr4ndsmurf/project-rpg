using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour
{
    #region Singleton

    public static PlayerManager instance;

    private void Awake()
    {
        instance = this;
    }

    #endregion

    public GameObject player;

    public bool canMove = true;
    public bool canAttack = true;
    public void KillPlayer()
    {
        GetComponent<MenuManager>().OpenRetryScene();
    }
}
