using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zadanie2 : MonoBehaviour
{
    public float speed = 10f;
    private bool opening = false;
    private bool closing = false;
    private bool isOpen = false;
    private readonly float startPosition = 0f;
    private readonly float endPosition = 3f;
    private bool playerOnTrigger = false;
    private Transform doorTransform;

    void Start()
    {
        doorTransform = transform.Find("Door");
        if (doorTransform == null)
        {
            Debug.LogError("door not found");
        }
    }

    void Update()
    {
        if (playerOnTrigger)
        {
            if (!isOpen)
            {
                opening = true;
            }
        }
        else
        {
            if (isOpen)
            {
                closing = true;
                isOpen = false;
            }
        }

        if (opening && doorTransform.position.z >= endPosition)
        {
            opening = false;
            isOpen = true;
        }
        else if (closing && doorTransform.position.z <= startPosition)
        {
            closing = false;
            isOpen = false;
        }
        else if (opening || closing)
        {
            Vector3 moveDirection = opening ? transform.forward : -transform.forward;
            Vector3 move = moveDirection * speed * Time.deltaTime;
            doorTransform.Translate(move);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player near the door.");
            playerOnTrigger = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player not near the door.");
            playerOnTrigger = false;
        }
    }
}