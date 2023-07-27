using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI; // Need to add this otherwise it wont work

public class MoveToObject : MonoBehaviour
{
    private NavMeshAgent _agent;

    public GameObject moveToObject;

    private void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        if (Input.GetMouseButton(0)) // This is left click; changed to one would be right click
        {
            MoveAgentToPoint(true); // Move agent to where left click is pressed when pressed down
        }
    }
    void MoveAgentToPoint(bool isFollowMouse) // boolean; true or false statement
    {

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); //Cheap way of running a ray from the camera

        // Get information about the collider the raycast hit
        RaycastHit hitinfo;

        // Run the raycast
        if (Physics.Raycast(ray.origin, ray.direction, out hitinfo)) // Has to hit a collider or wont recognise anything. If it hits something it will enter the if statement below
        {
            if (isFollowMouse)
            {
                _agent.destination = hitinfo.point;
            }
            else
            {
                // Follow the game obj (in this case the sphere)
                _agent.destination = moveToObject.transform.position;
            }
        }
    }
}
