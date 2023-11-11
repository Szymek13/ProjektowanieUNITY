using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zadanie3 : MonoBehaviour
{
    public float speed = 3f;
    private Vector3[] edges;
    private int current_edge = 0;
    private int next_edge = 1;

    void Start()
    {
        edges = new Vector3[]
        {
            new Vector3 (0, 0, 0),
            new Vector3 (10, 0, 0),
            new Vector3 (10, 0, 10),
            new Vector3 (0, 0, 10)
        };
    }

    void Update()
    {
        float movement = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, edges[current_edge], movement);

        if (transform.position == edges[current_edge])
        {
            current_edge = (current_edge + 1) % edges.Length;
            Vector3 direction = edges[next_edge] - transform.position;
            Quaternion rotation = Quaternion.LookRotation(direction);
            transform.rotation = rotation * Quaternion.Euler(0, -90, 0);
            next_edge = (next_edge + 1) % edges.Length;
        }
    }
}
