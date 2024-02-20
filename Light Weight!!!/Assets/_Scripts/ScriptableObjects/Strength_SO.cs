using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ExerciseStrength", menuName = "InputSettings")]
public class Strength_SO : ScriptableObject
{
    public float squatStrength;
    public float benchStrength;
    public float deadliftStrength;

    public float s_gainedStrength;
    public float b_gainedStrength;
    public float d_gainedStrength;
}
