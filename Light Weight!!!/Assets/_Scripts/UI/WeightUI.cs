using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WeightUI : MonoBehaviour
{
    public static WeightUI Instance { get; private set; }

    public TextMeshProUGUI weightLevel;
    public TextMeshProUGUI exercise;
    public TextMeshProUGUI exerciseExplain;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        exercise.text = ExerciseManager.Instance.currentMashType.ToString();
        exerciseExplain.text = ExerciseExplain();
    }

    public void IncreaseWeightLevel()
    {
        if (ExerciseManager.Instance.weightLevel < 10) ExerciseManager.Instance.weightLevel++;

        weightLevel.text = "Level " + ExerciseManager.Instance.weightLevel;
        ExerciseManager.Instance.WeightChange();
    }
    public void DecreaseWeightLevel()
    {
        if (ExerciseManager.Instance.weightLevel > 1) ExerciseManager.Instance.weightLevel--;

        weightLevel.text = "Level " + ExerciseManager.Instance.weightLevel;
        ExerciseManager.Instance.WeightChange();
    }

    public string ExerciseExplain()
    {
        switch (ExerciseManager.Instance.currentMashType)
        {
            case MashType.Squat:
                return "Mash '" + InputManager.Instance.keybinds.squatMash + "' !!!";
            case MashType.Bench:
                return "Mash '" + InputManager.Instance.keybinds.benchMash[0] + "' & '" + InputManager.Instance.keybinds.benchMash[1] +"' !!!";
            case MashType.Deadlift:
                return "Scroll UP!!!";
            default: return null;
        }
    }
}
