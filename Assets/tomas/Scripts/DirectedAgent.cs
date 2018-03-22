using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class DirectedAgent : MonoBehaviour
{
    public WorldGeneration mainWorldGeneration;
    private Vector3 destination;
    private NavMeshAgent agent;

    private bool startMovement = false;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        destination = transform.position + new Vector3(30.0f, 0, 0);
        Invoke("StartMovement", 1.0f);
    }

    void Update()
    {
        if(startMovement == true)
            NewDestinationMove();
    }

    bool StartMovement()
    {
        return startMovement = true;
    }
    void NewDestinationMove()
    {
        destination = transform.position + new Vector3(30.0f, 0, 0);
        agent.destination = destination;
        /*if (Vector3.Distance(transform.position, destination) > 1.0f)
        {
            agent.destination = destination;
        }
        else
        {
            if (true) //TODO: set when agent needs to stop
            {
                destination = transform.position + new Vector3(30.0f, 0, 0);
            }
        }*/
    }
}
