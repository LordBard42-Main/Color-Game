using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetLevel : MonoBehaviour, IReset
{
    public event IReset.LevelReset OnLevelReset;

    public void Reset()
    {
        OnLevelReset?.Invoke();
    }
}
