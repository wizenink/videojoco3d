using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageBehaviour : StateMachineBehaviour {

	// OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
	//override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
       
    //}

	// OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
	//override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	//
	//}

	// OnStateExit is called when a transition ends and the state machine finishes evaluating this state
	override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {

        Character character = animator.GetComponent<Character>(); // Getting the characte
        if (!animator.GetBool("hitInDamage")) // The character was not damaged in animation time
        {
            character.State = new StandState(animator, character); // Change character state to default state
            animator.SetBool("hitInDamage", false); // Reset hitInDamage
        }
        animator.SetBool("damaged", false); // Attack animation ended
        animator.ResetTrigger("hitted"); // Reset Trigger
        if (character.State.GetType() == typeof(DamageState)) 
            ((DamageState)character.State).AnimationFinished(); // notifies end of animation to the state object
    }

	// OnStateMove is called right after Animator.OnAnimatorMove(). Code that processes and affects root motion should be implemented here
	//override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	//
	//}

	// OnStateIK is called right after Animator.OnAnimatorIK(). Code that sets up animation IK (inverse kinematics) should be implemented here.
	//override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	//
	//}
}
