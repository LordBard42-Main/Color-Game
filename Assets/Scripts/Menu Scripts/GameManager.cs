using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{

    #region  Singleton

    public static GameManager instance;

    private void Awake()
    {

        if (instance != null)
        {
            Debug.LogWarning("GameManager already exists");
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(this);

    }
    #endregion

}
