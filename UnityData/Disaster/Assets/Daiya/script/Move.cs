using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour {

    private Vector3 initialPosition;
    public float a;
    public float s;

    void Start() {

        initialPosition = transform.localPosition;

    }

    void Update() {

        float z = a * Mathf.Sin(Time.time * s);
        transform.position = initialPosition + new Vector3(z, 0, 0);

    }

}
