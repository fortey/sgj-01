using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level2Manager : MonoBehaviour
{
    public PlateCircleController plate;
    public float EndLevelTime = 15f;

    public GameObject Planet;
    private void Start()
    {
        plate.onWin = Win;
        plate.onLose = Lose;
    }

    void Win()
    {
        SceneManager.LoadScene("Level1");
    }

    void Lose()
    {
        SceneManager.LoadScene("Level2");
    }

    private void Update()
    {
        EndLevelTime -= Time.deltaTime;
        if (EndLevelTime < 2)
        {
            Planet.SetActive(true);
        }
        if (EndLevelTime < 0)
        {
            Win();
        }
    }
}
