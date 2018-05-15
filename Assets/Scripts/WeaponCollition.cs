using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SoundUtil;

public class WeaponCollition : MonoBehaviour {

    public GameObject parent;

    BoxCollider coll;

    float duration;

    private void Update()
    {
        duration -= Time.deltaTime;
        if (duration <= 0){
            coll.enabled = false;
        }
    }

    private void Awake()
    {
        coll = GetComponent<BoxCollider>();
        coll.enabled = false;
    }

    public void StartCollitionCheck(float dur)
    {
        coll.enabled = true;
        duration = dur;
    }

    void OnTriggerEnter(Collider collision)
    {
        Debug.Log("atacameeeeee");
		if (collision.gameObject.tag.Equals("enemy") &&(parent.GetComponent<Character>().State.GetType() == typeof(AttackState)))
		{
			// AUDIO
			SoundUtil.SoundUtil.PlayRandomSkeletonHit();
			// AUDIO
			collision.gameObject.SendMessage("GetHit");
		}

    }
    private void OnCollisionStay(Collision collision)
    {
      
    }
    private void OnCollisionExit(Collision collision)
    {

    }
}
