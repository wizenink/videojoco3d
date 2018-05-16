using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SoundUtil;

public class WeaponCollition : MonoBehaviour {

    public GameObject parent;

    BoxCollider coll;

    float duration;
    float delay;


    private void Update()
    {
        duration -= Time.deltaTime;
        
        if (duration <= delay)
        {
            Debug.Log(Time.deltaTime);
            coll.enabled = true;
        }

        if (duration <= 0){
            coll.enabled = false;
        }
    }

    private void Awake()
    {
        coll = GetComponent<BoxCollider>();
        coll.enabled = false;
    }

    public void StartCollitionCheck(float dur, float del)
    {
        duration = dur;
        delay = del;
    }

    void OnTriggerEnter(Collider collision)
    {
		string tag;
		if (parent.tag.Equals("Player"))
			tag = "enemy";
		else tag = "Player";
		if (collision.gameObject.tag.Equals(tag) &&(parent.GetComponent<Character>().State.GetType() == typeof(AttackState)))
		{
			// AUDIO
			SoundUtil.SoundUtil.PlayRandomSkeletonHit();
			// AUDIO
			collision.gameObject.SendMessage("GetHit");
		}

    }
}
