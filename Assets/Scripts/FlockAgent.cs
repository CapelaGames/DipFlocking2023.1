using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class FlockAgent : MonoBehaviour
{
    public Flock agentFlock;
    [HideInInspector]
    public Collider2D agentCollider;

    public void SetUp(Flock flock)
    {
        agentFlock = flock;
        agentCollider = GetComponent<Collider2D>();
    }

    public void Move(Vector2 velocity)
    {
        transform.up = velocity.normalized;
        transform.position += (Vector3)velocity * Time.deltaTime;
    }
}
