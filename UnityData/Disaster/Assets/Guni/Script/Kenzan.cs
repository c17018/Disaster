using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Kenzan : MonoBehaviour {
    GameObject Player;

    [SerializeField]
    GameObject BloodEffect;

    GameObject MainCamera;

    void Start () {
        MainCamera = GameObject.FindWithTag("MainCamera");
	}

    void OnTriggerEnter2D(Collider2D other) {
        Player = GameObject.FindWithTag("Player");
        if (other.gameObject.tag == "Player") {
            Destroy(Player);
            Instantiate(BloodEffect, Player.transform.position,Player.transform.rotation);
            MainCamera.GetComponent<AudioSource>().volume = 0;
            Invoke("Reload", 2);
        }
    }

    void Reload() {
	    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}