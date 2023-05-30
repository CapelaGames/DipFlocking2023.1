using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Flock/Behaviour/Alignment", fileName = "Alignment")]
public class AlignmentBehaviour : Behaviour
{
    public override Vector2 CalculateMove(FlockAgent agent,
        List<Transform> context,
        Flock flock)
    {
        if (context.Count == 0)
        {
            return agent.transform.up;
        }

        Vector2 alignmentMove = Vector2.zero;

        int count = 0;
        foreach (Transform item in context)
        {
            alignmentMove += (Vector2)item.transform.up;
            count++;
        }

        if (count != 0)
        {
            alignmentMove /= count;
        }

        return alignmentMove;
    }
}
