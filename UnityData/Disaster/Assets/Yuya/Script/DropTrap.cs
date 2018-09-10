using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropTrap : MonoBehaviour
{
    public GameObject trap;

    private void Awake()
    {
        trap.SetActive(false);
    }

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
            trap.SetActive(true);
        }          
    }
}
