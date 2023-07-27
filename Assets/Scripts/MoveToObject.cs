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
            MoveAgentToPoint(true); // Move agent to where left click is pressed when pressed down (can click and drag)
            moveToObject = null; // Need to set it to null so we have full control or after a right click it wont move as being overridden (_agent.destination = moveToObject.transform.position)
        }

        if (Input.GetMouseButton(1))
        {
            MoveAgentToPoint(false);
        }

        if (moveToObject != null) // if not equal to null...
        {
            _agent.destination = moveToObject.transform.position; // Move the agent
        }
    }
    void MoveAgentToPoint(bool isFollowMouse) // boolean; true or false statement
    {
        // Create the ray itself. This creates the data for our raycast.
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); //Cheap way of running a ray from the camera; doesnt care about clicking or not. This is done in a previous statement

        // Store information about what the raycast hit (has to have a collider??)
        RaycastHit hitinfo;

        // Run the raycast. Get information about the ray. It starts at the Camera (origin) and draws a line in the direction to the mouse. Whatever hit is the desination of the Agent
        if (Physics.Raycast(ray.origin, ray.direction, out hitinfo)) // Has to hit a collider or wont recognise anything. If it hits something it will enter the if statement below
        {
            if (isFollowMouse)
            {
                _agent.destination = hitinfo.point; // _ is used in front of Agent as it is a private variable (I dont know why yet...)
            }
            else
            {
                // Follow the game obj (in this case the sphere)
                moveToObject = hitinfo.transform.gameObject;

            }
        }
    }
}
