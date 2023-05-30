using System.Collections;
using System.Collections.Generic;
using TMPro.EditorUtilities;
using UnityEngine;

[CreateAssetMenu(menuName = "Flock/Behaviour/Stay In Radius", fileName = "Stay In Radius")]
public class StayInRadiusBehaviour : Behaviour
{
    [SerializeField] 
    private Vector2 _center;
    [SerializeField] 
    private float _radius = 15f;
    
    public override Vector2 CalculateMove(FlockAgent agent,
        List<Transform> context,
        Flock flock)
    {
        Vector2 centerDirection = _center - (Vector2)agent.transform.position;

        float t = centerDirection.magnitude / _radius;

        if (t < 0.9f)
        {
            return Vector2.zero;
        }

        return centerDirection * t * t;
    }
}
