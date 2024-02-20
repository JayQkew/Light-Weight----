using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneUI : MonoBehaviour
{
    public static SceneUI Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    public void GoToExercise(int exerciseNo)
    {
        SceneManager.LoadScene(exerciseNo);
    }

    public void Exit()
    {
        Application.Quit();
    }
}
