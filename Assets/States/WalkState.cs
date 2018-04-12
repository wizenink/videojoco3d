using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkState : CharacterState
{
    public WalkState(Animator animator, Character player) : base(animator, player)
    {
        player.Speed = player.WalkSpeed; // Cambio de la velocidad a la de correr
        animator.SetBool("running", false); // Desactivar la variable running en el controlador de animaciones
        animator.SetBool("isMoving", true); // Activar la variable isMoving en el controlador de animaciones
    }

    // Métodos NO Permitidos por el estado
    public override void Walk() { }

    // Métodos Permitidos por el estado
    public override void FollowPath(string path)
    {
        throw new System.NotImplementedException();
    }
    
    public override void ScapeFromTarget()
    {
        throw new System.NotImplementedException();
    }
    
}
