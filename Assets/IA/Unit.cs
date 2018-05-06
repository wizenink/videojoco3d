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

    private void Awake()
    {
       
    }
    void Start()
    {
        character = GetComponent<Character>();
        PathRequestManager.RequestPath(transform.position, target.position, OnPathFound);
    }

    private void FixedUpdate()
    {
        Vector3 targetPos = target.position;
        if (lastPos != targetPos)
            PathRequestManager.RequestPath(transform.position, targetPos, OnPathFound);

        lastPos = targetPos;
    }

    private void Update()
    {

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
        Vector3 currentWaypoint = path[0];
        while (true)
        {
            if (transform.position == currentWaypoint)
            {
                targetIndex++;
                if (targetIndex >= path.Length)
                {
                    yield break;
                }
                currentWaypoint = path[targetIndex];
            }

            
            Vector3 direction = currentWaypoint - this.transform.position;
            state = character.State;
            state.Run();
            this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(direction), 0.1f);
            state = character.State;
            state.Walk();
            transform.position = Vector3.MoveTowards(transform.position, currentWaypoint, character.Speed * Time.deltaTime);

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