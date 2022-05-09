using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class patrolling : MonoBehaviour
{

    [SerializeField] Transform[] CheckPoints;

    NavMeshAgent agent;
    int destinationPoint = 0;
    // Start is called before the first frame update
    void Start()
    {
        
        agent = GetComponent<NavMeshAgent>();
        nextDestination();

    }

    // Update is called once per frame
    void Update()
    {
        //Go to the next destination
        nextDestination();

    }

    private void nextDestination(){
        
        if (CheckPoints.Length == 0) {
            
            Debug.LogWarning("The movement of the ghost is not set");
            return;

        }
        
        agent.SetDestination(CheckPoints[destinationPoint].position);

        //return to the first check point after reaching the last one
        destinationPoint = (destinationPoint + 1) % CheckPoints.Length;
    }
}