using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnockbackState : CharacterState {

    public KnockbackState(Animator animator, Character character) : base(animator, character)
    {
        character.Speed = 0.0f; // You cant move while getting damage
        animator.SetBool("knockedback", true); // Set true to activate the animation
    }

    // Methods where the state does nothing //

    public override void Attack() { }
    public override void Walk() { }
    public override void Run() { }
    public override void Stand() { }
    public override void GetHit() { }

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
