using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class ShotgunShooting : MonoBehaviour
{
    [SerializeField]
    private GameObject bulletPrefab;
    [SerializeField]
    private float bulletSpeed;
    [SerializeField]
    private Transform firstBarrelOffset;
    [SerializeField]
    private Transform secondBarrelOffset;
    [SerializeField]
    private float shotsPerSecond;
    [SerializeField]
    private GameObject parent;
    private Boolean isFiring;
    private float timeBeforeShot;
    public AudioClip shotgunSound;
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    private void FireBullet()
    {
        GameObject firstBullet = Instantiate(bulletPrefab, firstBarrelOffset.position, parent.transform.rotation);
        GameObject secondBullet = Instantiate(bulletPrefab, secondBarrelOffset.position, parent.transform.rotation);
        Rigidbody2D rigidbodyFirstBullet = firstBullet.GetComponent<Rigidbody2D>();
        Rigidbody2D rigidbodySecondBullet = secondBullet.GetComponent<Rigidbody2D>();
        rigidbodyFirstBullet.velocity = bulletSpeed * parent.transform.up;
        rigidbodySecondBullet.velocity = bulletSpeed * parent.transform.up;
        audioSource.PlayOneShot(shotgunSound);
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
