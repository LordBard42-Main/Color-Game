using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IReset
{

    public delegate void LevelReset();
    public event LevelReset OnLevelReset;

    public void Reset();
}
