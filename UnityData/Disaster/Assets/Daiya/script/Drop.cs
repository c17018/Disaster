using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drop : MonoBehaviour {
    GameObject player;
    bool one = false;


    // Use this for initialization
    void Start() {
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update() { 
        if (player != null) {
            if (player.transform.position.x >= gameObject.transform.position.x - 40) {
                transform.Translate(0, -15, 0);
                one = true;
            } else if (player.transform.position.x < gameObject.transform.position.x - 40 && one) {
                transform.Translate(0, -15, 0);
            }
        }
    }   
}

