using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDestroyer : MonoBehaviour
{
    public string[] targetTags;  // Tags of objects to target
    public float destroyTime;    // Time to destroy targeted objects
    public float moveSpeed;      // Speed to move towards targeted objects

    private GameObject closestTarget;  // Closest target to move towards
    private float destroyTimer;        // Timer to destroy targeted objects

    void Update()
    {
        // Find closest target
        closestTarget = FindClosestTarget();

        // Move towards closest target
        if (closestTarget != null)
        {
            transform.position = Vector2.MoveTowards(transform.position, closestTarget.transform.position, moveSpeed * Time.deltaTime);

            // Check if close enough to target to destroy it
            if (Vector2.Distance(transform.position, closestTarget.transform.position) < 0.1f)
            {
                // Destroy target after delay
                destroyTimer += Time.deltaTime;
                if (destroyTimer >= destroyTime)
                {
                    Destroy(closestTarget);
                    destroyTimer = 0;
                }
            }
        }
    }

    GameObject FindClosestTarget()
    {
        GameObject closest = null;
        float closestDistance = Mathf.Infinity;

        // Find closest object with target tag
        foreach (string tag in targetTags)
        {
            GameObject[] targets = GameObject.FindGameObjectsWithTag(tag);
            foreach (GameObject target in targets)
            {
                float distance = Vector2.Distance(transform.position, target.transform.position);
                if (distance < closestDistance)
                {
                    closest = target;
                    closestDistance = distance;
                }
            }
        }

        return closest;
    }
}
