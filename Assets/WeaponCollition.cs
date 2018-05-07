using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponCollition : MonoBehaviour {

    private void OnCollisionEnter(Collision collision)
    {
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
