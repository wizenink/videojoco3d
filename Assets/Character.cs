using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour {

    private Animator animator; // Control class for animation states
    private float speed; // Current speed
    private CharacterState state; // Current CharacterState
    private bool shiftIsPressed; // :)


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
    }


    private void Update()
    {

        // Lógica de control del personaje, esto deberia gestionarse en una clase aparte //

        var x = Input.GetAxis("Horizontal");
        var z = Input.GetAxis("Vertical");
        
        if (Input.GetKeyDown("space"))
        {
            state.Attack();
        }

        if (Input.GetKeyDown("left shift"))
        {
            shiftIsPressed = true;
        }

        if (Input.GetKeyUp("left shift"))
        {
            shiftIsPressed = false;
        }

        if (shiftIsPressed && (x != 0 || z != 0))
        {
            state.Run();
        }

        if (!shiftIsPressed && (x != 0 || z != 0))
        {
            state.Walk();
        }

        if (x==0 && z == 0)
        {
            state.Stand();
        }

        // Debug and test code (will be removed) //
        if (Input.GetKeyDown(KeyCode.E)) 
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

        // Aplicación de la velocidad del personaje //
        // Esto está mal el personaje necesita movimiento más complejo y usando Time.deltaTime :)

        transform.Translate(x*Speed, 0, 0);
        transform.Translate(0, 0, z*Speed);
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
