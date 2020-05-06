using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
   public AudioSource Audio;

    private void Start()
    {
        
    }
    public void OnStartPressed()
    {
        Audio.Play();
        StartCoroutine(LoadAnotherLevel("Level2"));       
    }

    IEnumerator LoadAnotherLevel(string levelName)
    {
        yield return new WaitForSeconds(0.2f);
        SceneManager.LoadScene(levelName);
    }
}
