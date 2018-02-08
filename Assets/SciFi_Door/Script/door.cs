using UnityEngine;
using System.Collections;

public class door : MonoBehaviour {
    
	GameObject thedoor;

    void OnTriggerEnter ( Collider obj ){
        if (obj.tag == "Player")
        {
            thedoor = GameObject.FindWithTag("SF_Door");
            thedoor.GetComponent<Animation>().Play("open");
        }
    }

    void OnTriggerExit ( Collider obj ){
        if (obj.tag == "Player")
        {
            thedoor = GameObject.FindWithTag("SF_Door");
            thedoor.GetComponent<Animation>().Play("close");
        }
    }
}