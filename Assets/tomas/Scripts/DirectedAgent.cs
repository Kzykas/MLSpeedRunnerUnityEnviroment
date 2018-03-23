using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class DirectedAgent : MonoBehaviour
{
    public WorldGeneration mainWorldGeneration;
    private Vector3 destination;
    private Vector3 prevDestination;
    private NavMeshAgent agent;

    public float moveByXamount = 10.0f;

    private bool startMovement = false;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
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
        
        destination = transform.position + new Vector3(moveByXamount, 0, 0);
        agent.destination = destination;
        if(true)
        {
            if (prevDestination == destination) //This is to prevent random stuck points
            {
                if(moveByXamount <= 30)
                    moveByXamount++;
                else
                    moveByXamount--;
            } 
        }
        prevDestination = destination;
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
