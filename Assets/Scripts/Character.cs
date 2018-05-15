using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour {

    protected Animator animator; // Control class for animation states
    protected float speed; // Current speed
    protected CharacterState state; // Current CharacterState
    

    // Editor Variables //
    [SerializeField]
    [Tooltip("Number of hits to kill the character")]
    protected int healthPoints;

    [SerializeField]
    [Tooltip("Character walk speed")]
    protected float walkSpeed;

    [SerializeField]
    [Tooltip("Character running speed")]
    protected float runningSpeed;

    [SerializeField]
    [Tooltip("Number of hits to produce knockback")]
    protected int comboedHits;

    public WeaponCollition weapon;

    // ---------------- //

    void Start()
    {
        animator = GetComponent<Animator>();
        state = new StandState(animator, this);
    }


    private void Update()
    {
        if (this.gameObject.name == "Enemy")
            Debug.Log(this.state);
       
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
