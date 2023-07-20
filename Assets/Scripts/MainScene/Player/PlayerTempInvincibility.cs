using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTempInvincibility : MonoBehaviour
{
    [SerializeField]
    private float invincibilityDuration;

    private InvincibilityController invincibilityController;

    private void Awake()
    {
        invincibilityController = GetComponent<InvincibilityController>();
    }
    public void StartInvincibility()
    {
        invincibilityController.InvincibilityStart(invincibilityDuration);
    }
}
