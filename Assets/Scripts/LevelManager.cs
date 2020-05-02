using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public CharController plate;

    private void Start()
    {
        plate.onWin = Win;
        plate.onLose = Lose;
    }

    void Win()
    {
        SceneManager.LoadScene("Final");
    }

    void Lose()
    {
        SceneManager.LoadScene("Level1");
    }
}
