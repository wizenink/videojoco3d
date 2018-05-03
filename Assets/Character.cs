using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour {

    private Animator animator; // Control class for animation states
    private float speed; // Current speed
    private CharacterState state; // Current CharacterState
    private bool shiftIsPressed; // :)

    private float rotationSpeed;
    public GameObject cameraPosition;
    private Vector3 directionVector;
    private float angle;

    // Editor Variables //
    [SerializeField]
    [Tooltip("Number of hits to kill the character")]
    private int healthPoints;

    [SerializeField]
    [Tooltip("Character walk speed")]
    private float walkSpeed;

    [SerializeField]
    [Tooltip("Character running speed")]
    private float runningSpeed;

    [SerializeField]
    [Tooltip("Number of hits to produce knockback")]
    private int comboedHits;

    // ---------------- //

    void Start()
    {
        animator = GetComponent<Animator>();
        state = new StandState(animator, this);
        shiftIsPressed = false;
        rotationSpeed = 0;
        directionVector = Vector3.zero;
    }


    private void Update()
    {

        // Lógica de control del personaje, esto deberia gestionarse en una clase aparte //

        //var x = Input.GetAxis("Horizontal") * Time.deltaTime * 150.0f;
        //var z = Input.GetAxis("Vertical") * Time.deltaTime * 3.0f;

        Vector3 direction = Vector3.ProjectOnPlane(this.transform.position - cameraPosition.transform.position, transform.TransformDirection(Vector3.up));

        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(h, 0, v);
        
        Vector3 directionVectorH = Vector3.Cross(direction, Vector3.down*h);
        Vector3 directionVectorV = direction*v;

        directionVector = directionVectorH + directionVectorV;


        Debug.Log(GameObject.Find("Main Camera").transform.position);
        Debug.Log(Camera.main.GetComponent<Transform>().position);
        Debug.DrawLine(this.transform.position, this.transform.position + (directionVector * 100), Color.red);
        Debug.DrawLine(this.transform.position, this.transform.position-direction*100, Color.red);



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
            state.Run();
        }

        if (!shiftIsPressed && directionVector != Vector3.zero)
        {
            state.Walk();
        }

        if (directionVector == Vector3.zero)
        {
            state.Stand();
        }

        // Debug and test code (will be removed) //
        if (Input.GetKeyDown(KeyCode.T))
        {
            Debug.Log(state);
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            state.GetHit();
        }

        if (Input.GetKeyDown(KeyCode.K))
        {
            state.Dead();
        }

        Transform trans = GetComponent<Transform>();

        if (directionVector != Vector3.zero)
        {
            angle = Vector3.SignedAngle(this.transform.TransformDirection(Vector3.forward), directionVector, Vector3.up);
        } else
        {
            angle = 0f;
        }

        if (angle > -5 | angle < 5)
        {
            rotationSpeed = 3*angle;
        }
        else
        {
            rotationSpeed = 0;
        }

        // Aplicación de la velocidad del personaje //
        // Esto está mal el personaje necesita movimiento más complejo y usando Time.deltaTime :)

        trans.Translate(0, 0, 1* Speed* Time.deltaTime);
        trans.Rotate(0, Time.deltaTime * rotationSpeed, 0);
    }

    public void GetHit()
    {
        state.GetHit();
    }

    // Getters and Setters de C# //

    public CharacterState State
    {
        get
        {
            return state;
        }

        set
        {
            state = value;
        }
    } 

    public float Speed
    {
        get
        {
            return speed;
        }

        set
        {
            speed = value;
        }
    } 

    public float RunningSpeed
    {
        get
        {
            return runningSpeed;
        }

    }

    public float WalkSpeed
    {
        get
        {
            return walkSpeed;
        }

    }

    public int ComboedHits
    {
        get
        {
            return comboedHits;
        }

        set
        {
            comboedHits = value;
        }
    }

    public int HealthPoints
    {
        get
        {
            return healthPoints;
        }

        set
        {
            healthPoints = value;
        }
    }
}
