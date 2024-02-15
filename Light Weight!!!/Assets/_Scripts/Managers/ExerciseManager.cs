using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExerciseManager : MonoBehaviour
{
    public static ExerciseManager Instance { get; private set; }

    public MashType currentMashType;


    [Header("Right/Centre")]
    public float strength_Both;
    public float strength_R;    
    public float strength_L;    

    public GameObject barbell;
    public Rigidbody2D barbell_rb;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        barbell_rb = barbell.GetComponent<Rigidbody2D>();

        // set weight and min/max positions
        switch (currentMashType)
        {
            case MashType.Squat:
                InputManager.Instance.mainMashEvent.AddListener(PushRep_R);
                break;
            case MashType.Deadlift:
                InputManager.Instance.thirdMashEvent.AddListener(PushRep_R);

                break;
            case MashType.Bench:
                InputManager.Instance.secondaryMashEvent_R.AddListener(PushRep_R);
                InputManager.Instance.secondaryMashEvent_L.AddListener(PushRep_L);
                break;
        }
    }

    private void Update()
    {
        //MashUpdate();
    }

    public void PushRep_R()
    {
        barbell_rb.AddForce(Vector2.up * strength_R, ForceMode2D.Impulse);
    }

    public void PushRep_L()
    {
        barbell_rb.AddForce(Vector2.up * strength_L, ForceMode2D.Impulse);
    }
}

public enum MashType
{
    None,
    Squat,
    Bench,
    Deadlift
}
