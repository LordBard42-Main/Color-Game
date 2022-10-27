using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PointerController : MonoBehaviour, IDirectional
{

    [SerializeField]
    private float rotationalDirection;

    public event IDirectional.DirectionUpdated OnDirectionUpdated;

    private Dictionary<float, Vector2> directionMap = new Dictionary<float, Vector2>()
    {
        { 0f, Vector2.up },
        { 90f, Vector2.left },
        { -90f, Vector2.right },
        { 180f, Vector2.down },
    };

    public void RotateLeft()
    {

        rotationalDirection += 90;
        if (rotationalDirection > 180)
            rotationalDirection = -90f;

        SetPointerRotation();
        
        var directionVector = directionMap[rotationalDirection];
        OnDirectionUpdated?.Invoke(directionVector);
    }

    public void RotateRight()
    {
        rotationalDirection -= 90f;
        if (rotationalDirection < -90f)
            rotationalDirection = 180f;

        SetPointerRotation();
        
        var directionVector = directionMap[rotationalDirection];
        OnDirectionUpdated?.Invoke(directionVector);

    }

    private void SetPointerRotation()
    {
        transform.eulerAngles = new Vector3(0, 0, rotationalDirection);

    }


}
