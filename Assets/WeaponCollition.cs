using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponCollition : MonoBehaviour {

    public GameObject parent;

    private void OnCollisionEnter(Collision collision)
    {

        if (parent != collision.gameObject && (parent.GetComponent<Character>().State.GetType() == typeof(AttackState)))
            collision.gameObject.SendMessage("GetHit");

    }
    private void OnCollisionStay(Collision collision)
    {
        
    }
    private void OnCollisionExit(Collision collision)
    {
        Debug.Log("exit");
    }
}
