using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Relation : MonoBehaviour
{     
    
	void Start ()
    {
		
	}  	
	
	void Update ()
    {
		
	}

    private void OnTriggerStay2D(Collider2D hit)
    {
        if (hit.gameObject.tag == "Player")
        {
            hit.gameObject.transform.parent = gameObject.transform;
        }          
    }

    private void OnTriggerExit2D(Collider2D hit)
    {
        hit.transform.parent = null;
    }
}
