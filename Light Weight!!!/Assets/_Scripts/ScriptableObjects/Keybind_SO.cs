using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ScriptableObjects", menuName = "InputSettings")]
public class Keybind_SO : ScriptableObject
{
    public KeyCode mainMash = KeyCode.Space;
    public KeyCode[] secondaryMash =
    {
        KeyCode.A,
        KeyCode.L
    };
}
