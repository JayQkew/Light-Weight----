using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InputManager : MonoBehaviour
{
    public static InputManager Instance { get; private set; }

    public Keybind_SO keybinds;

    public UnityEvent mainMashEvent;

    public UnityEvent secondaryMashEvent_A;

    public UnityEvent secondaryMashEvent_B;

    public UnityEvent thirdMashEvent;

    private void Awake()
    {
        Instance = this;
    }

    private void Update()
    {
        switch (MashManager.Instance.currentMashType)
        {
            case MashType.Main:
                if (Input.GetKeyDown(keybinds.mainMash)) mainMashEvent.Invoke();
                break;
            case MashType.Secondary:
                if (Input.GetKeyDown(keybinds.secondaryMash[0])) secondaryMashEvent_A.Invoke();
                if (Input.GetKeyDown(keybinds.secondaryMash[1])) secondaryMashEvent_B.Invoke();
                break;
            case MashType.Third:
                if (Input.mouseScrollDelta.y == -1) thirdMashEvent.Invoke();
                break;
            default:
                break;
        }

    }

}

