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

    // Abstract Methods //

    public abstract void FollowPath(string path);
    public abstract void ScapeFromTarget();

    // Virtual Methods //
    // Default behaviour is "change the player state"

    public virtual void Attack()
    {
        character.State = new AttackState(animator, character); 
    }

    public virtual void GetHit()
    {
        character.State = new DamageState(animator, character);
    }

    public virtual void SetTarget(Character target)
    {
        this.target = target;
    }
    
    public virtual void Stand()
    {
        character.State = new StandState(animator, character);
    }

    public virtual void ReleaseTarget()
    {
        this.target = null;
    }

    public virtual void Run()
    {
        character.State = new RunState(animator, character);
    }

    public virtual void Walk()
    {
        character.State = new WalkState(animator, character);
    }
}
