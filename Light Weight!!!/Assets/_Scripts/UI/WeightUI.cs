using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class WeightUI : MonoBehaviour
{
    public static WeightUI Instance { get; private set; }

    public TextMeshProUGUI weightLevel;
    public TextMeshProUGUI exercise;
    public TextMeshProUGUI exerciseExplain;
    public TextMeshProUGUI repText;

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

        // makes it so that the controller UI selection wont press the button again if "space" is pressed
        EventSystem.current.SetSelectedGameObject(null);
    }
    public void DecreaseWeightLevel()
    {
        if (ExerciseManager.Instance.weightLevel > 1) ExerciseManager.Instance.weightLevel--;

        weightLevel.text = "Level " + ExerciseManager.Instance.weightLevel;
        ExerciseManager.Instance.WeightChange();
        EventSystem.current.SetSelectedGameObject(null);
    }

    public string ExerciseExplain()
    {
        switch (ExerciseManager.Instance.currentMashType)
        {
            case MashType.squat:
                return "Mash '" + InputManager.Instance.keybinds.squatMash + "' !!!";
            case MashType.bench:
                return "Mash '" + InputManager.Instance.keybinds.benchMash[0] + "' & '" + InputManager.Instance.keybinds.benchMash[1] +"' !!!";
            case MashType.deadlift:
                return "Scroll UP!!!";
            default: return null;
        }
    }

    public void RepCount(int reps)
    {
        repText.text = reps.ToString("00");
    }
}
