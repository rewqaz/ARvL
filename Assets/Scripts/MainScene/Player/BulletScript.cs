using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    private Camera cameraBul;
    private void Awake()
    {
        cameraBul = Camera.main;
    }
    private void Update()
    {
        OffScreen();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<EnemyMovement>())
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
            ScoreCounter.scoreValue += 1;
        }
    }
    private void OffScreen()
    {
        Vector2 screenPosition = cameraBul.WorldToScreenPoint(transform.position);
        if (screenPosition.x < 0 || screenPosition.x > cameraBul.pixelWidth || screenPosition.y < 0 || screenPosition.y > cameraBul.pixelHeight)
        {
            Destroy(gameObject);
        }
    }
}
