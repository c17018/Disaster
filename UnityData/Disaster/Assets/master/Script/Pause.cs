using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class Pause : MonoBehaviour {

    // Use this for initialization
    GameObject Camera;
    public GameObject endtxt;
    public GameObject titletxt;

    public bool pause = true;

    void Start() {     
        Camera = GameObject.FindWithTag("MainCamera");
        endtxt.SetActive(false);
        titletxt.SetActive(false);
    }

    void Update() {       
      
    }

    public void PauseButton() {
        if (pause == true) {
            pause = false;
            endtxt.SetActive(true);
            titletxt.SetActive(true);
            Time.timeScale = 0;
            Camera.GetComponent<AudioSource>().volume = 0;
            Camera.GetComponent<AudioSource>().pitch = 0;

        }
    }

    public void Title() {
        Time.timeScale = 1;
        SceneManager.LoadScene("Title");
    }

    public void Restart() {
        pause = true;
        endtxt.SetActive(false);
        titletxt.SetActive(false);
        Time.timeScale = 1;
        Camera.GetComponent<AudioSource>().volume = 1;
        Camera.GetComponent<AudioSource>().pitch = 1;


    }
}


