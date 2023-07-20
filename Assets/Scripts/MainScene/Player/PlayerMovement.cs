using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

//—оздание простейшей системы перемещени€ персонажа с помощью обновлЄнной системы передвижени€ и RigidBody в качестве базовой физики перемещени€

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rigidbodyPl;
    private Vector2 movementInput;
    [SerializeField]
    private float movementSpeed;
    [SerializeField]
    private float horizontalSpeed;
    [SerializeField]
    private float verticalSpeed;
    [SerializeField]
    private float screenBorder;
    private Vector2 smoothInput;
    private Vector2 smoothVelocity;
    private Camera camerapl;

    private void Awake()
    {
        camerapl = Camera.main;
        rigidbodyPl = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        SetPlayerVelocity();
        RotateInDirection();
    }

    private void SetPlayerVelocity()
    {
        smoothInput = Vector2.SmoothDamp(smoothInput, movementInput, ref smoothVelocity, 0.15f);

        rigidbodyPl.velocity = smoothInput * movementSpeed;
        PreventOffscreen();
    }
    private void PreventOffscreen()
    {
        Vector2 screenPosition = camerapl.WorldToScreenPoint(transform.position);

        if ((screenPosition.x < screenBorder && rigidbodyPl.velocity.x < 0) || screenPosition.x > camerapl.pixelWidth - screenBorder && rigidbodyPl.velocity.x > 0)
        {
            rigidbodyPl.velocity = new Vector2(0, rigidbodyPl.velocity.y);
        }
        if ((screenPosition.y < screenBorder && rigidbodyPl.velocity.y < 0) || screenPosition.y > camerapl.pixelHeight - screenBorder && rigidbodyPl.velocity.y > 0)
        {
            rigidbodyPl.velocity = new Vector2(rigidbodyPl.velocity.x, 0);
        }
    }
    private void RotateInDirection()
    {
        Vector2 mouseScreenPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = (mouseScreenPosition - (Vector2)transform.position).normalized;
        transform.up = direction;
    }
    private void OnMove(InputValue inputValue)
    {
        movementInput = inputValue.Get<Vector2>();
    }
}
/*
 *  од работает по принципу считывани€ направлений движени€ в формате вектора (обновлЄнна€ InputSystem) и передачи этих данных 
 * в rigidbody персонажа, также с помощью SmoothDamp сделал нечто подоби€ инерции персонажа при передвижении (происходит замедление
 * после прекращени€ движени€)
 * */