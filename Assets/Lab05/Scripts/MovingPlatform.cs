using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public Transform startPoint; // Punkt początkowy
    public Transform endPoint;   // Punkt docelowy
    public float moveSpeed = 2f; // Prędkość poruszania się

    private bool movingToEnd = true;
    private bool playerOnPlatform = false;

    private void Update()
    {
        if (playerOnPlatform)
        {
            // Poruszaj platformę między punktami początkowym i docelowym, tylko gdy gracz jest na platformie
            if (movingToEnd)
            {
                transform.position = Vector3.MoveTowards(transform.position, endPoint.position, moveSpeed * Time.deltaTime);

                if (Vector3.Distance(transform.position, endPoint.position) < 0.01f)
                {
                    movingToEnd = false;
                }
            }
            else
            {
                transform.position = Vector3.MoveTowards(transform.position, startPoint.position, moveSpeed * Time.deltaTime);

                if (Vector3.Distance(transform.position, startPoint.position) < 0.01f)
                {
                    movingToEnd = true;
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Jeśli gracz wejdzie na platformę, ustaw flagę playerOnPlatform na true
            playerOnPlatform = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Jeśli gracz opuści platformę, ustaw flagę playerOnPlatform na false
            playerOnPlatform = false;
        }
    }
}
