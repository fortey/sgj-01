using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level2Manager : MonoBehaviour
{
    public PlateCircleController plate;
    public float EndLevelTime = 15f;

    public GameObject Planet;
    public AudioSource Music;
    private void Start()
    {
        plate.onWin = Win;
        plate.onLose = Lose;
        StartCoroutine(PlayMusic());
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
        if (EndLevelTime < 1)
        {
            Planet.SetActive(true);
            plate.Landing();
        }
        if (EndLevelTime < 0)
        {
            Win();
        }
    }

    IEnumerator PlayMusic()
    {
        yield return new WaitForSeconds(1);
        Music.Play();
    }
}
