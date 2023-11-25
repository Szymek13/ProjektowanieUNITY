using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zadanie3 : MonoBehaviour
{
    public List<Vector3> waypoints = new List<Vector3>();
    public float platformSpeed = 1.8f;
    private int currentPoint = 0;
    private bool movingForward = true;
    public bool isMoving = false;

    void Start()
    {
        if (waypoints.Count > 0)
        {
            transform.position = waypoints[0];
        }
    }

    void Update()
    {
        if (isMoving && waypoints.Count > 0)
        {
            MoveToWaypoint();
        }
    }

    private void MoveToWaypoint()
    {
            Vector3 targetWaypoint = waypoints[currentPoint];
            Vector3 moveDirection = (targetWaypoint - transform.position).normalized;
            transform.position += platformSpeed * Time.deltaTime * moveDirection;

            if (Vector3.Distance(transform.position, targetWaypoint) < 0.1f)
            {
                if (movingForward)
                {
                    if (currentPoint >= waypoints.Count - 1)
                    {
                        Debug.Log("Moving backwards");
                        movingForward = false;
                        currentPoint = waypoints.Count - 2;
                    }
                    else
                    {
                        currentPoint++;
                    }
                }
                else
                {
                    if (currentPoint <= 0)
                    {
                        currentPoint = 1;
                        Debug.Log("at the start");
                        movingForward = true;
                        isMoving = false;
                    }
                    else
                    {
                        currentPoint--;
                    }
                }
            }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player entered the platform.");
            isMoving = true;
        }
    }
}