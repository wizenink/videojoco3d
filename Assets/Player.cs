using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {



    private Animator animator;
    private float speed;

    void Start()
    {
        animator = GetComponent<Animator>();
        speed = 0.01f;
    }


    private void Update()
    {

        var x = Input.GetAxis("Horizontal");
        var z = Input.GetAxis("Vertical");
        
        if (Input.GetKeyDown("space"))
        {
            animator.SetBool("attack",true);
            speed = 0.0f;
        }

        if (Input.GetKeyDown("left shift"))
        {
            animator.SetBool("running",true);
            speed = 0.05f;

        }
        if (Input.GetKeyUp("left shift"))
        {
            animator.SetBool("running", false);
            speed = 0.01f;

        }

        if (x != 0 || z != 0)
        {
            animator.SetBool("isMoving", true); 
        }else
        {
            animator.SetBool("isMoving", false);
        }

        transform.Translate(x*speed, 0, 0);
        transform.Translate(0, 0, z*speed);
    }
    
}
