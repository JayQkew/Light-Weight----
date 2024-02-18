using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ScriptableObjects", menuName = "InputSettings")]
public class Keybind_SO : ScriptableObject
{
    public KeyCode squatMash = KeyCode.Space;
    public KeyCode[] benchMash =
    {
        KeyCode.A,
        KeyCode.L
    };
}
