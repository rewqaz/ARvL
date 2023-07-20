using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class HealthUI : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private UnityEngine.UI.Image healthBarDynamicPart;

    public void UpdateBar(HealthController healthController)
    {
        healthBarDynamicPart.fillAmount = healthController.RemainingHealthPercentage;
    }
}
