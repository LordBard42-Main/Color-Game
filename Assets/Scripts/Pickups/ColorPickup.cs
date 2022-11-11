using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorPickup : IGameObject, IPickup
{
    [SerializeField]
    private ColorProperties colorProperties;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            if(collision.TryGetComponent(out ColorProperties colorProperties))
                colorProperties.AddColor(this.colorProperties.CurrentColor);
            else
                Debug.LogWarning("Player Does not have Color Properties");

            gameObject.SetActive(false);
        }
    }

    public void Reset()
    {
        gameObject.SetActive(true);
    }
}