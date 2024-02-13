using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MashManager : MonoBehaviour
{
    public static MashManager Instance { get; private set; }


    public MashType currentMashType;

    public float mashRate = 1f;     //decrease rate
    public float currentMashTime;
    public float maxMashTime = 1f;

    public TextMeshProUGUI timeDisplay;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        currentMashTime = maxMashTime;

        switch (currentMashType)
        {
            case MashType.None:
                break;
            case MashType.Main:
                InputManager.Instance.mainMashEvent.AddListener(MashIncrement);
                break;
            case MashType.Secondary:
                break;
            case MashType.Third:
                break;
        }
    }

    private void Update()
    {
        MashUpdate();
    }

    public void MashIncrement()
    {
        currentMashTime = maxMashTime;
    }

    public void MashUpdate()
    {
        currentMashTime = Mathf.MoveTowards(currentMashTime, 0, mashRate * Time.deltaTime);
        timeDisplay.text = currentMashTime.ToString("0.00");
    }

}

public enum MashType
{
    None,
    Main,
    Secondary,
    Third
}
