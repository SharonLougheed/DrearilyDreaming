using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistanceToTarget : MonoBehaviour {
    /// <summary>
    /// This script is to be placed on the player to calculate the distance to the
    /// target NPC at all times.
    /// </summary>

    public Transform targetNPC;     //the target's transform

    public static float distanceToTarget; //distance field

    private void Update() {
        distanceToTarget = Vector3.Distance(gameObject.transform.position, targetNPC.position);
        Debug.Log("Distance to Target NPC: " + distanceToTarget);
    }
}
