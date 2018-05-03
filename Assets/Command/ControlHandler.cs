using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlHandler : MonoBehaviour {

    float h;
    float v;
    // Use this for initialization
    void Start () {
        h = 0;
        v = 0;
    }
	
	// Update is called once per frame
	void Update () {



        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");

        
	}
}
