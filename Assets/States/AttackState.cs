using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : CharacterState
{
    public AttackState(Animator animator, Character character) : base(animator, character)
    {
        character.Speed = 0.0f; // En la animación de atacar el personaje no se puede mover
    }

    // Métodos NO Permitidos por el estado //

    public override void Attack() { }
    public override void Walk() { }
    public override void Run() { }
    public override void Stand() { }

    // Métodos NO Permitidos por el estado //

    public override void FollowPath(string path)
    {
        throw new System.NotImplementedException();
    }

    public override void ScapeFromTarget()
    {
        throw new System.NotImplementedException();
    }

}
