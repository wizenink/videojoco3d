using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EazyTools.SoundManager;
using SoundCte;
using SoundUtil;
using UnityEngine.SceneManagement;

public class Player: MonoBehaviour {

    public GameObject cameraPosition;
    
    private bool shiftIsPressed; // :)

    private float rotationSpeed;
    private Vector3 directionVector;
    private float angle;

    public Character player;
    private CharacterController controller;

    public WeaponCollition weaponCollition;

    private bool isAttacking;

	// AUDIO
	private int walkingSlow = -1;
	private Audio audioWalkingSlow;
	private int walkingFast = -1;
	private Audio audioWalkingFast;
	private AudioClip walkingSandFast;
	private AudioClip walkingSandSlow;
	// AUDIO

    private void Start()
    {
		// AUDIO
		SoundManager.PlaySound (SoundCte.SoundCte.LoadAudioClip (SoundCte.SoundCte.EFFECT_WALKING_SAND_FAST), 0.0f, false, null);
		walkingSandFast = SoundCte.SoundCte.LoadAudioClip (SoundCte.SoundCte.EFFECT_WALKING_SAND_FAST);
		walkingSandSlow = SoundCte.SoundCte.LoadAudioClip (SoundCte.SoundCte.EFFECT_WALKING_SAND_SLOW);
		// AUDIO

        shiftIsPressed = false;
        rotationSpeed = 0;
        directionVector = Vector3.zero;
        //player = GetComponent<Character>();
        controller = GetComponent<CharacterController>();

    }


	public void GetHit(){
		player.GetHit ();
	}


    private void LateUpdate()
    {
        if(isAttacking)
            transform.rotation = Quaternion.LookRotation(new Vector3(cameraPosition.transform.forward.x,0.0f, cameraPosition.transform.forward.z),Vector3.up);
    }
    // Update is called once per frame
    void Update () {
		Debug.Log (player.HealthPoints);
        Vector3 direction = Vector3.ProjectOnPlane(this.transform.position - cameraPosition.transform.position, transform.TransformDirection(Vector3.up));

        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(h, 0, v);

        Vector3 directionVectorH = Vector3.Cross(direction, Vector3.down * h);
        Vector3 directionVectorV = direction * v;

        directionVector = directionVectorH + directionVectorV;

		if (player.HealthPoints <= 0) 
		{
			SceneManager.LoadScene ("DeathMenu");
		}

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
			// AUDIO
			CheckAudioRun ();
			// AUDIO
            player.State.Run();
        }

        if (!shiftIsPressed && directionVector != Vector3.zero)
        {
			// AUDIO
			CheckAudioWalk ();
			// AUDIO
            player.State.Walk();
        }

        if (Input.GetButtonDown("Fire1"))
        {
            // AUDIO
            SoundUtil.SoundUtil.PlayRandomSwordMiss();
            // AUDIO
            player.State.Attack();

            angle = Vector3.SignedAngle(this.transform.TransformDirection(Vector3.forward), direction, Vector3.up);
            //cameraPosition.transform.forward;
            isAttacking = true;

        }
        else
        {
            isAttacking = false;
        }

        if (directionVector == Vector3.zero)
        {
			// AUDIO
			CheckAudioStand ();
			// AUDIO
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

        
        directionVector = directionVector.normalized * player.Speed;
        controller.Move(directionVector * Time.deltaTime);
        controller.Move(Physics.gravity);

        
        trans.Rotate(0, Time.deltaTime * rotationSpeed * player.Speed * 0.7f, 0);

    }

	private void CheckAudioWalk(){
		// AUDIO
		audioWalkingFast = SoundManager.GetAudio (walkingFast);
		if (audioWalkingFast != null) {
			audioWalkingFast.Stop();
		}
		audioWalkingSlow = SoundManager.GetAudio (walkingSlow);
		if (audioWalkingSlow == null) {
			walkingSlow = SoundManager.PlaySound (walkingSandSlow, 1.0f, true, null);
		} else if (!audioWalkingSlow.playing) {
			walkingSlow = SoundManager.PlaySound (walkingSandSlow, 1.0f, true, null);
		}
		// AUDIO
	}

	private void CheckAudioRun(){
		// AUDIO
		audioWalkingSlow = SoundManager.GetAudio (walkingSlow);
		if (audioWalkingSlow != null) {
			audioWalkingSlow.Stop();
		}
		audioWalkingFast = SoundManager.GetAudio (walkingFast);
		if (audioWalkingFast == null) {
			walkingFast = SoundManager.PlaySound (walkingSandFast, 1.0f, true, null);
		} else if (!audioWalkingFast.playing) {
			walkingFast = SoundManager.PlaySound (walkingSandFast, 1.0f, true, null);
		}
		// AUDIO
	}

	private void CheckAudioStand(){
		// AUDIO
		if (audioWalkingFast != null) {
			audioWalkingFast.Stop ();
		}
		if (audioWalkingSlow != null) {
			audioWalkingSlow.Stop ();
		}
		// AUDIO
	}
}
