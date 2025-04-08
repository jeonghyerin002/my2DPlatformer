using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTraceControlle : MonoBehaviour
{
    public float moveSpeed = .5f;
    public float raycastDistance = .2f;
    public float traceDistance = 2f;

    private Transform player;
    
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    private void Update()
    {
        Vector2 direction = player.position - transform.position;

        if (direction.magnitude > traceDistance)
            return;

        Vector2 directionNormalize = direction.normalized;

        RaycastHit2D[] hit = Physics2D.RaycastAll(transform.position, directionNormalize, raycastDistance);
        Debug.DrawRay(transform.position, directionNormalize * raycastDistance, Color.red);

        foreach(RaycastHit2D rHit in hit)
        {
            if (rHit.collider.CompareTag("Obstacle"))
            {
                Vector3 alternativeDirection = Quaternion.Euler(0f, 0f, -90f) * direction;
                transform.Translate(alternativeDirection * moveSpeed * Time.deltaTime);
            }
            else
            {
                transform.Translate(direction * moveSpeed * Time.deltaTime);
            }
        }
    }
}
