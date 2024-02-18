using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExerciseManager : MonoBehaviour
{
    public static ExerciseManager Instance { get; private set; }

    public MashType currentMashType;

    /// <summary>
    /// PLAYER GAINS STRENGTHS AFTER 5 REPS RELATIVE TO THE WEIGHT THEY ARE LIFTING
    /// PLAYERS CAN CHOOSE WEIGHTS
    /// </summary>

    [Header("Exercise")]
    public Strength_SO playerStrength;
    public float strength;
    public Vector3 handDistance;

    public GameObject barbell;
    public Rigidbody2D barbell_rb;
    public GameObject[] plates;
    [Range(1, 10)]
    public int weightLevel;

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
                strength = playerStrength.squatStrength * 30f;
                InputManager.Instance.squatMashEvent.AddListener(PushRep);
                break;
            case MashType.Deadlift:
                strength = playerStrength.deadliftStrength * 7.5f;
                InputManager.Instance.deadliftMashEvent.AddListener(PushRep);
                break;
            case MashType.Bench:
                strength = playerStrength.benchStrength * 1000f;
                InputManager.Instance.benchMashEvent_R.AddListener(PushRepAt_R);
                InputManager.Instance.benchMashEvent_L.AddListener(PushRepAt_L);
                break;
        }
    }


    public void PushRep() => barbell_rb.AddForce(Vector2.up * strength, ForceMode2D.Impulse);
    public void PushRepAt_R() => barbell_rb.AddForceAtPosition(Vector2.up * strength, barbell.transform.position + handDistance);
    public void PushRepAt_L() => barbell_rb.AddForceAtPosition(Vector2.up * strength, barbell.transform.position - handDistance);

    public void WeightChange()
    {
        foreach(var plate in plates)
        {
            plate.transform.localScale = new Vector3(0.2f * weightLevel, plate.transform.localScale.y);
        }

        barbell_rb.mass = 20 + (weightLevel * 5);
    }

}

public enum MashType
{
    None,
    Squat,
    Bench,
    Deadlift
}