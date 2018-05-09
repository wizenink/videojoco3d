using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class OTSCamera : MonoBehaviour {

    public GameObject shoulder;
    public Camera cam;
    public Transform target;
    public float distance = 5.0f;
    public float xSpeed = 120.0f;
    public float ySpeed = 120.0f;

    public float yMinLimit = -20f;
    public float yMaxLimit = 80f;

    public float distanceMin = .5f;
    public float distanceMax = 15f;

    public float parriba = 0;

    private Rigidbody rigidbody2;

    [Header("Raycast matrix properties")]
    public float offset;
    public int number;

    float x = 0.0f;
    float y = 0.0f;

    // Use this for initialization
    void Start () {
        Vector3 angles = transform.eulerAngles;
        x = angles.y;
        y = angles.x;

        rigidbody2 = GetComponent<Rigidbody>();

        // Make the rigid body not change rotation
        if (rigidbody2 != null)
        {
            rigidbody2.freezeRotation = true;
        }
    }

    void LateUpdate()
    {
        int layer = LayerMask.NameToLayer("Player");
        int layermask = layer << 8;
        layermask = ~layermask;
        if (target)
        {
            x += Input.GetAxis("Mouse X") * xSpeed * 0.02f;
            y -= Input.GetAxis("Mouse Y") * ySpeed * 0.02f;

            y = ClampAngle(y, yMinLimit, yMaxLimit);

            Quaternion rotation = Quaternion.Euler(y, x, 0);

            distance = Mathf.Clamp(distance - Input.GetAxis("Mouse ScrollWheel") * 5, distanceMin, distanceMax);

            RaycastHit hit;

            Vector3 rayPosition = transform.position;
            bool didHit = Physics.Linecast(target.position,rayPosition, out hit);
            //Debug.Log(layer);
            if (didHit)
                {
                    //Debug.Log(layermask);
                    Debug.Log("Raycast collided");
                    distance -= hit.distance;
           
                }
            
            Vector3 negDistance = new Vector3(0.0f, 0.0f, -distance);
            Vector3 position = rotation * negDistance + target.position + Vector3.up * parriba;

            transform.rotation = rotation;
            transform.position = position;
        }
    }

    public static float ClampAngle(float angle, float min, float max)
    {
        if (angle < -360F)
            angle += 360F;
        if (angle > 360F)
            angle -= 360F;
        return Mathf.Clamp(angle, min, max);
    }
}
