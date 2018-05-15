using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : CharacterState
{
    public AttackState(Animator animator, Character character) : base(animator, character)
    {
        character.Speed = 0.0f; // You cant move while attacking
        animator.SetBool("attack", true); // Set true to activate the animation
        character.weapon.StartCollitionCheck(1.0f,0.5f);
    }

    // Methods where the state does nothing //

    public override void Attack() { }
    public override void Walk() { }
    public override void Run() { }
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
