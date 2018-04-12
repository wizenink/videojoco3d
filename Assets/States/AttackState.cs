using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : CharacterState
{
    public AttackState(Animator animator, Character character) : base(animator, character)
    {
        character.Speed = 0.0f; // En la animación de atacar el personaje no se puede mover
        animator.SetBool("attack", true); // Cambia el estado de la variable de control de animación
    }

    // Métodos NO Permitidos por el estado //
    // Aqui se hace override de las acciones que el estado no debería responder dejandolas sin implementación

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
