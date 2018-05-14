using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AssemblyCSharp
{

	public class IA : MonoBehaviour {

		public int playerDmg;


		protected Transform target; //Transform to move forward
		protected Character character;
		protected CharacterState state;

		// Use this for initialization
		void Start () {
			target = GameObject.FindGameObjectWithTag("Player").transform;
			character = GetComponent<Character>();


		}
		
		// Update is called once per frame
		void Update () {
			Vector3 direction = target.position - this.transform.position;
			state = character.State;
			state.Run ();
			direction.y = 0;
			if (Vector3.Distance (target.position, this.transform.position) > 10) {
				this.transform.rotation = Quaternion.Slerp (this.transform.rotation, Quaternion.LookRotation (direction), 0.1f);
				state = character.State;
				state.Walk ();

			}
			else {
				if (direction.magnitude > 1) {

					state = character.State;
					state.Run ();
				} else { 
					state = character.State;
					state.Attack ();
				}	
			}
			this.transform.Translate (0, 0, character.Speed);
			
		}
	}

}
