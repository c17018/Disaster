using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class goTitle : MonoBehaviour {

    public void Title() {
        Time.timeScale = 1;
        SceneManager.LoadScene("Title");
    }
}
