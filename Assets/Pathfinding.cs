using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Pathfinding : MonoBehaviour
{
/*First, you will be making a public array of Transforms simply called points. 
This array will store the locations of the different points that will be set up in the next section. 
The object this script is attached to will make its way to each point one by one until you end the game. 
It will navigate towards these points using the Nav Mesh Agent component, 
and the code will store a reference of that component in the nav variable.
Finally, there’s the destPoint integer, which will be used to cycle through the different points laid out for Object */

    public Transform[] points;
    private NavMeshAgent nav;
    private int destPoint;


    // Start is called before the first frame update
    void Start()
    {
       nav = GetComponent<NavMeshAgent>(); 
    }

    // Update is called once per frame fixedupdate can be run multiple times per frame
    void FixedUpdate()
    {
        if (!nav.pathPending && nav.remainingDistance < 0.5f) //if you have reached the destination then find the next point to travel to
  	    GoToNextPoint();

    }
    //finds the next point for the object to travel to
    void GoToNextPoint()
    {
  	if (points.Length == 0)
  	    {
  		return;
  	    }
  	nav.destination = points[destPoint].position;
  	destPoint = (destPoint + 1) % points.Length;
    }
}
