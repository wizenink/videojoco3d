using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageState : CharacterState
{
    private int comboedHitsCounter; // Counter of comboed hits
    private int animationPlaying; // Animations played

    public DamageState(Animator animator, Character character) : base(animator, character)
    {
        character.Speed = 0.0f; // You cant move while getting damage
        animator.SetBool("damaged", true); // Set true to activate the animation
        comboedHitsCounter = 1;
        character.HealthPoints --;
        animationPlaying = 1;
    }

    // Methods where the state does nothing //

    public override void Attack() { }
    public override void Walk() { }
    public override void Run() { }
    public override void Stand() { }

    // Methods where the state changes default behaviour //

    public override void GetHit()
    {
        animator.SetBool("hitInDamage",true);
        animator.SetTrigger("hitted");
        comboedHitsCounter++;
        animationPlaying++; // Adds animation
        if (comboedHitsCounter >= character.ComboedHits) // 
        {
            character.State = new KnockbackState(animator, character);
        }
    }

    public override void FollowPath(string path)
    {
        throw new System.NotImplementedException();
    }

    public override void ScapeFromTarget()
    {
        throw new System.NotImplementedException();
    }

    // own Methods //

    // this method controls damage animations being played
    // is called when a damage animation is finished
    // when all damage animations are finished changes the state to StandState
    public void AnimationFinished()
    {
        animationPlaying--;
        if (animationPlaying <= 0)
        {
            character.State = new StandState(animator, character);
        }
    }

    public int ComboedHitsCounter
    {
        get
        {
            return comboedHitsCounter;
        }

    }
}
