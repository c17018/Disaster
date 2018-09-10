using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStart : MonoBehaviour {
    public AudioClip StartSE;
    AudioSource AS;
    GameObject MC;

    void Start () {
        AS = gameObject.GetComponent<AudioSource>();
        MC = GameObject.FindWithTag("MainCamera");
	}

    void Update() {
        if (Input.GetButtonDown("Fire1")) {
            AS.clip = StartSE;
            AS.Play();
            MC.GetComponent<AudioSource>().volume = 0;
            Invoke("LoadStage01", 1);
        }
    }

    void LoadStage01(){
            SceneManager.LoadScene("Stage01");
    }

}
