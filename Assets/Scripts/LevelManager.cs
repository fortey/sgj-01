using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public CharController plate;
    public AudioSource ASource;
    public AudioClip FinishSound;

    private void Start()
    {
        plate.onWin = Win;
        plate.onLose = Lose;
    }

    void Win(string currentArea)
    {
        ASource.PlayOneShot(FinishSound);
        //Time.timeScale = 0.2f;
        var sceneName = currentArea == "cows" ? "Titles" : "Final";
        StartCoroutine(LoadAnotherLevel(sceneName));
    }

    void Lose()
    {
        SceneManager.LoadScene("Level1");
    }

    IEnumerator LoadAnotherLevel(string sceneName)
    {
        yield return new WaitForSeconds(1f);
        //Time.timeScale = 1f;
        SceneManager.LoadScene(sceneName);
    }
}
