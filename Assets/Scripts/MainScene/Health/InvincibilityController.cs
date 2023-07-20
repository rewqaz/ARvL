using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvincibilityController : MonoBehaviour
{
    private HealthController healthController;
    private void Awake()
    {
        healthController= GetComponent<HealthController>();

    }
    public void InvincibilityStart(float duration)
    {
        StartCoroutine(InvincibilitySet(duration));
    }

    private IEnumerator InvincibilitySet(float duration)
    {
        healthController.isInvincible = true;
        yield return new WaitForSeconds(duration);
        healthController.isInvincible = false;
    }
}
