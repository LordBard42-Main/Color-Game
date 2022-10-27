using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ColorSelector))]
public class ColorSelectorUI : MonoBehaviour
{

    [SerializeField]
    private Transform colorSlotPrefab;

    [SerializeField]
    private Transform colorSlotParent;

    [SerializeField]
    private Transform colorSelectorCanvas;

    private ColorSelector colorSelector;


    private List<Transform> colorSlots = new List<Transform>();

    private void Awake()
    {
        colorSelector = GetComponent<ColorSelector>();
        
    }

    private void Start()
    {
        colorSelector.OnUpdatedColorSelectVisibility += DisplayUI;
        colorSelector.OnColorSlotAdded += AddColorSlot;
        
        StartCoroutine(WaitForFrame());

        IEnumerator WaitForFrame()
        {
            yield return new WaitForEndOfFrame();
            colorSelectorCanvas.gameObject.SetActive(false);
        }
    }

    private void OnDestroy()
    {
        colorSelector.OnUpdatedColorSelectVisibility -= DisplayUI;
        colorSelector.OnColorSlotAdded -= AddColorSlot;

    }

    public void DisplayUI(Vector2 position, bool isOpen, ColorProperties colorProperties)
    {
        Debug.Log(isOpen);
        if (isOpen)
        {
            transform.position = position;
            var colorList = colorProperties.ColorList;

            foreach(PrimaryColors color in colorList)
            {
                AddColorSlot(color);
            }
        }
        else
        {
            while(colorSlots.Count > 0)
            {
                var slot = colorSlots[0];
                colorSlots.RemoveAt(0);
                Destroy(slot.gameObject);
            }
        }
        colorSelectorCanvas.gameObject.SetActive(isOpen);
    }

    public void AddColorSlot(PrimaryColors color)
    {
        var newSlot = Instantiate(colorSlotPrefab, colorSlotParent);

        StartCoroutine(WaitForFrame());

        IEnumerator WaitForFrame()
        {
            yield return new WaitForEndOfFrame();
            Debug.Log(newSlot.GetComponent<ColorSlot>());
            newSlot.GetComponent<ColorSlot>().CreateSlot(color, colorSelector);
            colorSlots.Add(newSlot);
        }
    }
    

}
