using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{

    [SerializeField]
    Vector2 playerStartLocation;

    // Start is called before the first frame update
    void Start()
    {
        var playerObject = GameObject.FindGameObjectWithTag("Player");
        playerObject.GetComponentInParent<PlayerMovement>().TeleportPlayer(playerStartLocation);
    }

}
