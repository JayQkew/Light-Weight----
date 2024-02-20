using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InputManager : MonoBehaviour
{
    public static InputManager Instance { get; private set; }

    public Keybind_SO keybinds;

    public UnityEvent squatMashEvent;

    public UnityEvent benchMashEvent_R;

    public UnityEvent benchMashEvent_L;

    public UnityEvent deadliftMashEvent;

    private void Awake()
    {
        Instance = this;
    }

    private void Update()
    {
        switch (ExerciseManager.Instance.currentMashType)
        {
            case MashType.squat:
                if (Input.GetKeyDown(keybinds.squatMash)) squatMashEvent.Invoke();
                break;
            case MashType.bench:
                if (Input.GetKeyDown(keybinds.benchMash[0])) benchMashEvent_L.Invoke();
                if (Input.GetKeyDown(keybinds.benchMash[1])) benchMashEvent_R.Invoke();
                break;
            case MashType.deadlift:
                if (Input.mouseScrollDelta.y > 0) deadliftMashEvent.Invoke();
                break;
            default:
                break;
        }

    }

}

