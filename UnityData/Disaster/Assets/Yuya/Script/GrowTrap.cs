using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrowTrap : MonoBehaviour
{
    public GameObject grow;
    int count = 0;

    private void Awake()
    {
        grow.SetActive(false);
    }

    void Start ()
    {
		
	}  	
	
	void Update ()
    {
        if (count >= 2)
        {
            grow.SetActive(true);
        }                                		
	}

    private void OnTriggerEnter2D(Collider2D hit)
    {
        if (hit.gameObject.tag == "Player")
        {
            count++;
        }           
    }
}
