using UnityEngine;
using System.Collections;

public class Unit : MonoBehaviour
{


    public Transform target;
    float speed = 20;
    Vector3[] path;
    Character character;
    CharacterState state;
    int targetIndex;
    Vector3 lastPos;
    int counter;
    private CharacterController controller;
    

    private void Awake()
    {
       
    }
    void Start()
    {
        character = GetComponent<Character>();
        PathRequestManager.RequestPath(transform.position, target.position, OnPathFound);
        counter = 0;
        controller = GetComponent<CharacterController>();
        
    }

    private void Update()
    {
        if (counter == 10) {
            Vector3 targetPos = target.position;
            if (lastPos != targetPos)
            {
                PathRequestManager.RequestPath(transform.position, targetPos, OnPathFound);
                Debug.Log("cheguei aqui");
            }
            lastPos = targetPos;
            counter = 0;
        }
        counter++;
    }

    public void OnPathFound(Vector3[] newPath, bool pathSuccessful)
    {
        if (pathSuccessful)
        {
            path = newPath;
            targetIndex = 0;
            StopCoroutine("FollowPath");
            StartCoroutine("FollowPath");
        }
    }

    IEnumerator FollowPath()
    {

        Vector3 currentWaypoint = target.position;
        if (path.Length != 0)
            currentWaypoint = path[0];
        

        while (true)
        {
            
            if (transform.position == currentWaypoint)
            {
                targetIndex++;
                if (targetIndex >= path.Length)
                {
                    yield break; ;
                }
                currentWaypoint = path[targetIndex];
            }

            
            Vector3 direction = currentWaypoint - this.transform.position;
            direction.y = 0;
            state = character.State;
            state.Run();
            this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(direction), 0.1f);
            state = character.State;
            state.Walk();

            controller.Move(Vector3.ClampMagnitude(new Vector3(direction.x, Physics.gravity.y, direction.z), character.Speed) * Time.deltaTime);
            
            Debug.DrawLine(transform.position, transform.position + Vector3.ClampMagnitude(new Vector3(direction.x, 0.0f, direction.z), character.Speed), Color.red);

            yield return null;

        }
    }
    
    public void OnDrawGizmos()
    {
        if (path != null)
        {
            for (int i = targetIndex; i < path.Length; i++)
            {
                Gizmos.color = Color.black;
                Gizmos.DrawCube(path[i], Vector3.one);

                if (i == targetIndex)
                {
                    Gizmos.DrawLine(transform.position, path[i]);
                }
                else
                {
                    Gizmos.DrawLine(path[i - 1], path[i]);
                }
            }
        }
    }
    
}