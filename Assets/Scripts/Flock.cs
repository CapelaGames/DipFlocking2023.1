using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

public class Flock : MonoBehaviour
{
    public FlockAgent agentPrefab;
    public List<FlockAgent> agents;

    public Behaviour behaviour;

    [Range(10, 500)] 
    public int startingCount = 250;
    public float agentDensity = 0.08f;

    [Range(1f, 10f)] 
    public float contextRadius = 1.5f;
    //skip this for now

    public float speed = 1f;

    private void Start()
    {
        for (int i = 0; i < startingCount; i++)
        {
            Vector2 randomLocation = Random.insideUnitCircle * startingCount * agentDensity;

            FlockAgent newAgent = Instantiate(agentPrefab,
                randomLocation,
                Quaternion.Euler(new Vector3(0, 0, Random.Range(0f, 360f))),
                transform
            );

            newAgent.name = "Agent " + (i + 1);
            agents.Add(newAgent);

        }
    }

    private void Update()
    {
        foreach (FlockAgent agent in agents)
        {
            List<Transform> context = GetNearbyObjects(agent);

            Vector2 move = behaviour.CalculateMove(agent, context, this);
            
            agent.Move(move * speed);
        }
    }
    private List<Transform> GetNearbyObjects(FlockAgent agent)
    {
        List<Transform> context = new List<Transform>();
        Collider2D[] contextColliders = Physics2D.OverlapCircleAll(agent.transform.position, contextRadius);

        /*context = contextColliders.ToList((x)=>x.tra);
        //testing
        context.Remove(agent.transform);*/

        foreach (Collider2D foundCollider in contextColliders)
        {
            if (foundCollider != agent.agentCollider)
            {
                context.Add(foundCollider.transform);
            }
        }

        return context;
    }
}
