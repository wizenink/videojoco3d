using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunState : CharacterState
{
    public RunState(Animator animator, Character character) : base(animator, character)
    {
        character.Speed = character.RunningSpeed; // Cambio de la velocidad a la de correr
        animator.SetBool("running", true); // Activar la variable running en el controlador de animaciones
        animator.SetBool("isMoving", true); // Activar la variable isMoving en el controlador de animaciones

    }

    // Métodos NO Permitidos por el estado //

    public override void Run() { }

    // Métodos Permitidos por el estado //

    public override void ScapeFromTarget()
    {
        throw new System.NotImplementedException();
    }

    public override void FollowPath(string path)
    {
        throw new System.NotImplementedException();
    }

}
