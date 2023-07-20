using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField]
    private float movementSpeed;

    [SerializeField]
    private float rotationSpeed;

    public Vector2 DirectionToPlayer { get; private set; }

    private Rigidbody2D rigidbodyEnm;

    private Vector2 targetDirection;
    

    private void Awake()
    {
        player = FindObjectOfType<PlayerMovement>().transform;
        rigidbodyEnm = GetComponent<Rigidbody2D>();
    }
    private Transform player;
    private void FixedUpdate()
    {
        Vector2 enemyToPlayerVec = player.position - transform.position;
        DirectionToPlayer = enemyToPlayerVec.normalized; 
        UpdateTargetDirection();
        RotateTowardsTarget();
        SetVelocity();
    }
    private void UpdateTargetDirection()
    {
        targetDirection = DirectionToPlayer;
    }
    private void RotateTowardsTarget()
    {
        Quaternion targetRotation = Quaternion.LookRotation(transform.forward, targetDirection);
        Quaternion rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

        rigidbodyEnm.SetRotation(rotation);
    }
    private void SetVelocity()
    {
        rigidbodyEnm.velocity = transform.up * movementSpeed;
    }
}
