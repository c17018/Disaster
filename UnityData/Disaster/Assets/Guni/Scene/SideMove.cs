using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideMove : MonoBehaviour {
    GameObject player;
    bool one = false;


    // Use this for initialization
    void Start() {
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update() { 
        if (player != null) {
            if (player.transform.position.y <= gameObject.transform.position.y + 15) {
                transform.Translate(0, +20, 0);
                one = true;
            } else if (player.transform.position.y > gameObject.transform.position.y + 15 && one) {
                transform.Translate(0, +20, 0);
            }
        }
    }   
}

