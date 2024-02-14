using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MashManager : MonoBehaviour
{
    public static MashManager Instance { get; private set; }

    public MashType currentMashType;

    [Header("Right/Centre")]
    
    //maximum change per increment
    //how fast the weight drops
    //can depend on stamina and weight lifted
    public float repRate_R = 1f;         
    
    public float currentRepCount_R;
    
    //change depending on weight
    //this is the weight the player is lifting
    public float weight_R = 1f;     
    
    //increment at each press
    //this increases the more the players muscles grow
    public float strength_R;    

    [Header("Left")]
    public float repRate_L = 1f;         
    public float currentRepCount_L;
    public float weight_L = 1f;     
    public float strength_L;    

    [Header("Sliders")]
    public Slider mashSlider;
    public Slider secondaryMashSlider_R;
    public Slider secondaryMashSlider_L;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        currentRepCount_R = weight_R;
        currentRepCount_L = weight_L;

        switch (currentMashType)
        {
            case MashType.None:
                break;
            case MashType.Squat:
            case MashType.Deadlift:
                InputManager.Instance.thirdMashEvent.AddListener(PushRep_R);
                InputManager.Instance.mainMashEvent.AddListener(PushRep_R);

                mashSlider.gameObject.SetActive(true);
                secondaryMashSlider_R.gameObject.SetActive(false);
                secondaryMashSlider_L.gameObject.SetActive(false);

                mashSlider.maxValue = weight_R;
                mashSlider.minValue = 0;
                break;
            case MashType.Bench:
                InputManager.Instance.secondaryMashEvent_R.AddListener(PushRep_R);
                InputManager.Instance.secondaryMashEvent_L.AddListener(PushRep_L);

                mashSlider.gameObject.SetActive(false);
                secondaryMashSlider_R.gameObject.SetActive(true);
                secondaryMashSlider_L.gameObject.SetActive(true);

                secondaryMashSlider_R.maxValue = weight_R;
                secondaryMashSlider_L.maxValue = weight_L;

                secondaryMashSlider_R.minValue = 0;
                secondaryMashSlider_L.minValue = 0;
                break;
        }
    }

    private void Update()
    {
        MashUpdate();
    }

    public void PushRep_R()
    {
        currentRepCount_R += strength_R;
        currentRepCount_R = Mathf.Clamp(currentRepCount_R, 0, weight_R);
    }

    public void PushRep_L()
    {
        currentRepCount_L += strength_L;
        currentRepCount_L = Mathf.Clamp(currentRepCount_L, 0, weight_L);
    }

    public void MashUpdate()
    {
        switch (currentMashType)
        {
            case MashType.Squat:
            case MashType.Deadlift:
                currentRepCount_R = Mathf.MoveTowards(currentRepCount_R, 0, repRate_R * Time.deltaTime);
                mashSlider.value = currentRepCount_R;
                break;
            case MashType.Bench:
                currentRepCount_R = Mathf.MoveTowards(currentRepCount_R, 0, repRate_R * Time.deltaTime);
                currentRepCount_L = Mathf.MoveTowards(currentRepCount_L, 0, repRate_L * Time.deltaTime);

                secondaryMashSlider_R.value = currentRepCount_R;
                secondaryMashSlider_L.value = currentRepCount_L;
                break;
        }
    }

}

public enum MashType
{
    None,
    Squat,
    Bench,
    Deadlift
}
