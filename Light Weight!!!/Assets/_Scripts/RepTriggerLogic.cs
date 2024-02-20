using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// WHEN THE PLAYER COMPLETES THE MOVEMENT
/// - Bench = top
///     - stay@Top = true
///     - enter@Bot = true
///     - enter@Top = check
/// - Deadlift = bottom
///     - stay@Bot = true
///     - enter@Top = true
///     - enter@Bot = check
/// - Squat = top
///     - stay@Top = true
///     - enter@Bot = true
///     - enter@Top = check
/// </summary>

public class RepTriggerLogic : MonoBehaviour
{
    public bool topTrigger;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "repCheck")
        {
            if (topTrigger)
            {
                switch (ExerciseManager.Instance.currentMashType)
                {
                    case MashType.squat:
                    case MashType.deadlift:
                        collision.GetComponent<RepCounterLogic>().RepCheck();
                        break;
                    case MashType.bench:
                        collision.GetComponent<RepCounterLogic>().topRep = true;
                        break;
                }
            }
            else
            {
                switch (ExerciseManager.Instance.currentMashType)
                {
                    case MashType.squat:
                    case MashType.deadlift:
                        collision.GetComponent<RepCounterLogic>().botRep = true;
                        break;
                    case MashType.bench:
                        collision.GetComponent<RepCounterLogic>().RepCheck();
                        break;
                }

            }

        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "repCheck")
        {
            if (topTrigger)
            {
                switch (ExerciseManager.Instance.currentMashType)
                {
                    case MashType.squat:
                    case MashType.deadlift:
                        collision.GetComponent<RepCounterLogic>().topRep = true;
                        break;
                }
            }
            else
            {
                switch (ExerciseManager.Instance.currentMashType)
                {
                    case MashType.bench:
                        collision.GetComponent<RepCounterLogic>().botRep = true;
                        break;
                }

            }

        }
    }
}
