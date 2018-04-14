using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkState : CharacterState
{
    public WalkState(Animator animator, Character player) : base(animator, player)
    {
        player.Speed = player.WalkSpeed; // Change speed to character walking speed
        animator.SetBool("running", false); // Set false to activate the animation
        animator.SetBool("isMoving", true); // Set true to activate the animation
    }

    // Methods where the state does nothing //

    public override void Walk() { }


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
