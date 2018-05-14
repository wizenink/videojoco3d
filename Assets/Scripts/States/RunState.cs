using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunState : CharacterState
{
    public RunState(Animator animator, Character character) : base(animator, character)
    {
        character.Speed = character.RunningSpeed; // Change speed to character running speed
        animator.SetBool("running", true); // Set true to activate the animation
        animator.SetBool("isMoving", true); // Set true to activate the animation

    }

    // Methods where the state does nothing //

    public override void Run() { }

    // Methods where the state changes default behaviour //

    public override void ScapeFromTarget()
    {
        throw new System.NotImplementedException();
    }

    public override void FollowPath(string path)
    {
        throw new System.NotImplementedException();
    }

}
