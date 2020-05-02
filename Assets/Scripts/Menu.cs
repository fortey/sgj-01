using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
   // public AudioSource Audio;

    private void Start()
    {
        //Audio.Play();
    }
    public void OnStartPressed()
    {
        SceneManager.LoadScene("Level2");
        
    }
}
