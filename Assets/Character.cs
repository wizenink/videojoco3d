using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour {

    private Animator animator; // Clase de control de los estados de las animaciones del character
    private float speed; // Velocidad actual del personaje
    private CharacterState state; // Estado actual del personaje
    private bool shiftIsPressed; // Indica si el shift esta pulsado


    /// Campos Visibles desde el editor
    [SerializeField]
    private float walkSpeed; // Define la velocidad al caminar (Se define en la interfaz de Unity)
    [SerializeField]
    private float runningSpeed; // Define la velocidad al correr (Se define en la interfaz de Unity)

    void Start()
    {
        animator = GetComponent<Animator>(); // Inicialización del controlador de animaciones
        state = new StandState(animator, this); // Estado inicial
        shiftIsPressed = false; // Control del estado del shift, esto deberia gestionarse en una clase aparte
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

        if (Input.GetKeyDown(KeyCode.E)) 
        {
            Debug.Log(state);
        }

        // Aplicación de la velocidad del personaje //
        // Esto está mal el personaje necesita movimiento más complejo y usando Time.deltaTime :)

        transform.Translate(x*Speed, 0, 0);
        transform.Translate(0, 0, z*Speed);
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

}
