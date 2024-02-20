using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraManager : MonoBehaviour
{
    public static CameraManager Instance { get; private set; }

    public CinemachineVirtualCamera VirtualCamera;

    public float cameraShakeIncrement = 0.01f;
    public float cameraShakeDecrease = 0.007f;

    public float amplitureShake;
    public float frequencyShake;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        switch (ExerciseManager.Instance.currentMashType)
        {
            case MashType.None:
                break;
            case MashType.squat:
                InputManager.Instance.squatMashEvent.AddListener(CameraShakeIncrease);
                break;
            case MashType.bench:
                InputManager.Instance.benchMashEvent_L.AddListener(CameraShakeIncrease);
                InputManager.Instance.benchMashEvent_R.AddListener(CameraShakeIncrease);
                break;
            case MashType.deadlift:
                InputManager.Instance.deadliftMashEvent.AddListener(CameraShakeIncrease);
                break;
        }
    }

    private void Update()
    {
        CinemachineBasicMultiChannelPerlin cinemachineBasicMultiChannelPerlin = VirtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();

        frequencyShake += cameraShakeDecrease * Time.deltaTime;
        amplitureShake += cameraShakeDecrease * Time.deltaTime;

        amplitureShake = Mathf.Clamp(amplitureShake, -0.4f, 0);
        frequencyShake = Mathf.Clamp(frequencyShake, -0.4f, 0);

        cinemachineBasicMultiChannelPerlin.m_AmplitudeGain = amplitureShake;
        cinemachineBasicMultiChannelPerlin.m_FrequencyGain = frequencyShake;
    }

    public void CameraShakeIncrease()
    {
        frequencyShake -= cameraShakeIncrement;
        amplitureShake -= cameraShakeIncrement;
    }
}
