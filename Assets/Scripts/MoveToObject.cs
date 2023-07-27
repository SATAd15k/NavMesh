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
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); //Cheap way of running a ray from the camera

        // Get information about the collider the raycast hit
        RaycastHit hitinfo;

        // Run the raycast
        if (Physics.Raycast(ray.origin, ray.direction, out hitinfo)) // Has to hit a collider or wont recognise anything. If it hits something it will enter the if statement below
            {

            }

        _agent.destination = moveToObject.transform.position;
    }
}
