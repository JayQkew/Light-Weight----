using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InputManager : MonoBehaviour
{
    public static InputManager Instance { get; private set; }

    public Keybind_SO keybinds;

    public UnityEvent mainMashEvent;

    public UnityEvent secondaryMashEvent_R;

    public UnityEvent secondaryMashEvent_L;

    public UnityEvent thirdMashEvent;

    private void Awake()
    {
        Instance = this;
    }

    private void Update()
    {
        switch (MashManager.Instance.currentMashType)
        {
            case MashType.Squat:
                if (Input.GetKeyDown(keybinds.mainMash)) mainMashEvent.Invoke();
                break;
            case MashType.Bench:
                if (Input.GetKeyDown(keybinds.secondaryMash[0])) secondaryMashEvent_L.Invoke();
                if (Input.GetKeyDown(keybinds.secondaryMash[1])) secondaryMashEvent_R.Invoke();
                break;
            case MashType.Deadlift:
                if (Input.mouseScrollDelta.y > 0) thirdMashEvent.Invoke();
                break;
            default:
                break;
        }

    }

}

