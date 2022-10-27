using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorPickup : MonoBehaviour, IGameObject, IPickup
{
    [SerializeField]
    private ColorProperties colorProperties;

    [SerializeField]
    private bool canMoveInto;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.tag);
        if(collision.tag == "Player")
        {
            if(collision.TryGetComponent(out ColorProperties colorProperties))
                colorProperties.AddColor(this.colorProperties.CurrentColor);
            else
                Debug.LogWarning("Player Does not have Color Properties");

            Destroy(gameObject);
        }
    }


    public bool CanMoveInto()
    {
        return canMoveInto;
    }

}