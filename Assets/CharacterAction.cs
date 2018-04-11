using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface CharacterAction {
    void Attack();
    void Run();
    void Walk();
    void FollowPath();
    void SetTarget();
    void ReleaseTarget();
    void ScapeFromTarget();
}
