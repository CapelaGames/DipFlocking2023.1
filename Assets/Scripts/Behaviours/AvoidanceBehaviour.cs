using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(menuName = "Flock/Behaviour/Avoidance", fileName = "Avoidance")]
public class AvoidanceBehaviour : Behaviour
{
    public override Vector2 CalculateMove(FlockAgent agent,
        List<Transform> context,
        Flock flock)
    {
        if (context.Count == 0)
        {
            return Vector2.zero;
        }

        Vector2 avoidanceMove = Vector2.zero;

        int count = 0;

        foreach (Transform item in context)
        {
            Vector3 directionFromItem = agent.transform.position - item.position;

            //experimental
            float t = Mathf.Clamp01(directionFromItem.magnitude / flock.contextRadius);
            t = 1 - t;
            directionFromItem *= t;
            
            avoidanceMove += (Vector2)directionFromItem;
            count++;
        }

        if (count != 0)
        {
            avoidanceMove /= count;
        }

        return avoidanceMove;
    }
}
