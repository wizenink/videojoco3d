using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandState : CharacterState
{   
    
    public StandState(Animator animator, Character character) : base(animator, character)
    {
        character.Speed = 0.0f; // You are not moving
        animator.SetBool("isMoving", false); // Set false to activate the animation
    }

    // Methods where the state does nothing //

    public override void Stand() { }


    // Methods where the state changes default behaviour //

    public override void FollowPath(string path)
    {
        throw new System.NotImplementedException();
    }

    public override void ScapeFromTarget()
    {
        throw new System.NotImplementedException();
    }

}
