using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorWheelController : MonoBehaviour
{

    public int Id;
    private Animator anim;
    private Image image;
    public string itemName;
    private bool selected;

    // Start is called before the first frame update
    void Awake()
    {
        anim = GetComponent<Animator>();
        image = GetComponent<Image>();
    }

    private void Start()
    {
        image.alphaHitTestMinimumThreshold = 0.5f;
    }

    public void  HoverEnter()
    {
        anim.SetBool("Hover", true);
    }

    public void  HoverExit()
    {
        anim.SetBool("Hover", false);
    }
}
