using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CharacterState {

    protected Animator animator;
    protected Character character;
    protected Character target;

    public CharacterState(Animator animator, Character character)
    {
        this.animator = animator;
        this.character = character;
    }

    // Métodos Abstractos //

    public abstract void FollowPath(string path);
    public abstract void ScapeFromTarget();

    // Métodos Virtuales //

    public virtual void Attack()
    {
        character.State = new AttackState(animator, character); // Cambia el estado del personaje
    }
    
    public virtual void Run()
    {
        character.State = new RunState(animator, character); // Cambia el estado del personaje
    }

    public virtual void SetTarget(Character target)
    {
        this.target = target;
    }
    
    public virtual void Stand()
    {
        character.State = new StandState(animator, character); // Cambia el estado del personaje
    }

    public virtual void ReleaseTarget()
    {
        this.target = null;
    }

    public virtual void Walk()
    {
        character.State = new WalkState(animator, character); // Cambia el estado del personaje
    }
}
