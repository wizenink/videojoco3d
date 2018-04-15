using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadState : CharacterState
{
    public DeadState(Animator animator, Character character) : base(animator, character)
    {
        animator.SetTrigger("dead");
    }

    // Methods where the state does nothing //

    public override void Attack() { }
    public override void Walk() { }
    public override void Run() { }
    public override void Stand() { }
    public override void GetHit() { }
    public override void FollowPath(string path) { }
    public override void ScapeFromTarget() { }

    // Methods where the state changes default behaviour //

}
