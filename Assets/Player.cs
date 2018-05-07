﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player: MonoBehaviour {

    public GameObject cameraPosition;
    private bool shiftIsPressed; // :)

    private float rotationSpeed;
    private Vector3 directionVector;
    private float angle;

    private Character player;

    private void Start()
    {
        shiftIsPressed = false;
        rotationSpeed = 0;
        directionVector = Vector3.zero;
        player = GetComponent<Character>();
    }

    // Update is called once per frame
    void Update () {

        Vector3 direction = Vector3.ProjectOnPlane(this.transform.position - cameraPosition.transform.position, transform.TransformDirection(Vector3.up));

        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(h, 0, v);

        Vector3 directionVectorH = Vector3.Cross(direction, Vector3.down * h);
        Vector3 directionVectorV = direction * v;

        directionVector = directionVectorH + directionVectorV;

        if (false)
        {
            Debug.Log(GameObject.Find("Main Camera").transform.position);
            Debug.Log(Camera.main.GetComponent<Transform>().position);
            Debug.DrawLine(this.transform.position, this.transform.position + (directionVector * 100), Color.red);
            Debug.DrawLine(this.transform.position, this.transform.position - direction * 100, Color.red);
        }

        if (Input.GetKeyDown("left shift"))
        {
            shiftIsPressed = true;
        }

        if (Input.GetKeyUp("left shift"))
        {
            shiftIsPressed = false;
        }

        if (shiftIsPressed && directionVector != Vector3.zero)
        {
            player.State.Run();
        }

        if (!shiftIsPressed && directionVector != Vector3.zero)
        {
            player.State.Walk();
        }

        if (Input.GetButtonDown("Fire1"))
        {
            player.State.Attack();
        }

        if (directionVector == Vector3.zero)
        {
            player.State.Stand();
        }

        if (Input.GetKeyUp(KeyCode.T))
        {
            Debug.Log(this.player.State);
        }

        Transform trans = GetComponent<Transform>();

        if (directionVector != Vector3.zero)
        {
            angle = Vector3.SignedAngle(this.transform.TransformDirection(Vector3.forward), directionVector, Vector3.up);
        }
        else
        {
            angle = 0f;
        }

        if (angle > -5 | angle < 5)
        {
            rotationSpeed = 3 * angle;
        }
        else
        {
            rotationSpeed = 0;
        }

        trans.Translate(0, 0, 1 * player.Speed * Time.deltaTime);
        trans.Rotate(0, Time.deltaTime * rotationSpeed, 0);

    }
}
