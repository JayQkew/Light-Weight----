using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepCounterLogic : MonoBehaviour
{
    public int repCount;

    public bool botRep;
    public bool topRep;

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
    public void RepCheck()
    {
        if (botRep && topRep)
        {
            repCount++;
            botRep = false;
            topRep = false;

            WeightUI.Instance.RepCount(repCount);

            if (repCount % 3 == 0)
            {
                ExerciseManager.Instance.IncreaseStrength();
            }
        }

    }
}
