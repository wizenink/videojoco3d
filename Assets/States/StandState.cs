using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandState : CharacterState
{   
    
    public StandState(Animator animator, Character character) : base(animator, character)
    {
        character.Speed = 0.0f; // Al inicio del estado cambia la velocidad del character
        animator.SetBool("isMoving", false); // Cambio de la variable isMoving en el controlador de animación
    }

    // Métodos NO Permitidos por el estado //
    // Aqui se hace override de las acciones que el estado no debería responder dejandolas sin implementación

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
