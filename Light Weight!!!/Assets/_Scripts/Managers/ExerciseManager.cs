using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExerciseManager : MonoBehaviour
{
    public static ExerciseManager Instance { get; private set; }

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

    public GameObject barbell;
    public Rigidbody2D barbell_rb;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        barbell_rb = barbell.GetComponent<Rigidbody2D>();

        currentRepCount_R = weight_R;
        currentRepCount_L = weight_L;

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
        currentRepCount_L += strength_L;
        currentRepCount_L = Mathf.Clamp(currentRepCount_L, 0, weight_L);
    }

    public void MashUpdate()
    {
        switch (currentMashType)
        {
            case MashType.Squat:
                barbell.transform.position = new Vector3(barbell.transform.position.x, Mathf.MoveTowards(barbell.transform.position.y, 0, Mathf.Sqrt(repRate_R) * Time.deltaTime));
                break;
            case MashType.Deadlift:
                barbell.transform.position = new Vector3(barbell.transform.position.x, Mathf.MoveTowards(barbell.transform.position.y, 0, Mathf.Sqrt(repRate_R) * Time.deltaTime));
                break;
            case MashType.Bench:
                currentRepCount_R = Mathf.MoveTowards(currentRepCount_R, 0, Mathf.Sqrt(repRate_R) * Time.deltaTime);
                currentRepCount_L = Mathf.MoveTowards(currentRepCount_L, 0, Mathf.Sqrt(repRate_L) * Time.deltaTime);
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
