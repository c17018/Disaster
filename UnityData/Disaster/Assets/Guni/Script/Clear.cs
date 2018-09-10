using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Clear : MonoBehaviour {
    private void OnTriggerEnter2D(Collider2D other) {
        int sceneNum;
        sceneNum = SceneManager.GetActiveScene().buildIndex;
        if (other.gameObject.tag == "Player") {
            SceneManager.LoadScene(++sceneNum);
        }
    }
}
