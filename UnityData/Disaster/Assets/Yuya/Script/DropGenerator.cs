using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropGenerator : MonoBehaviour
{
    public GameObject sword;
    public Transform DropPos;
	
	void Start ()
    {
		
	}   	
	
	void Update ()
    {
		
	}

    private void OnTriggerEnter2D(Collider2D hit)
    {
        if (hit.gameObject.tag == "Player")
        {
            Instantiate(sword, DropPos.position, DropPos.rotation);
        }
    }
}
