using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class droptest : MonoBehaviour {

    bool drop = false;


    // Use this for initialization
    void Start() {
      
    }

    // Update is called once per frame
    void Update() {
        Drop();
    }


    public void Drop() {
        if (drop) {
            if (gameObject.transform.position.y > -700) {
                transform.Translate(0, -10, 0);
            }
        }

    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "Player") {
            drop = true;
        }
        
    }
}