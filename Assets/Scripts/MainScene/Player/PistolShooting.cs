using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class PistolShooting : MonoBehaviour
{
    [SerializeField]
    private GameObject bulletPrefab;
    [SerializeField]
    private float bulletSpeed;
    [SerializeField]
    private Transform weaponOffset;
    [SerializeField]
    private float shotsPerSecond;
    [SerializeField]
    private GameObject parent;
    public AudioClip pistolSound;
    private Boolean isFiring;
    private AudioSource audioSource;
    private float timeBeforeShot;
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    private void FireBullet()
    {
        GameObject bullet = Instantiate(bulletPrefab, weaponOffset.position, parent.transform.rotation);
        Rigidbody2D rigidbody2 = bullet.GetComponent<Rigidbody2D>();
        audioSource.PlayOneShot(pistolSound);
        rigidbody2.velocity = bulletSpeed * parent.transform.up;
    }
    // Update is called once per frame
    void Update()
    {
        if (isFiring)
        {
            float timeSinceLastShot = Time.time - timeBeforeShot;
            if (timeSinceLastShot > shotsPerSecond)
            {
                FireBullet();
                timeBeforeShot = Time.time;
            }
        }
    }
    
    private void OnFire(InputValue inputValue)
    {
        isFiring = inputValue.isPressed;
    }
}
