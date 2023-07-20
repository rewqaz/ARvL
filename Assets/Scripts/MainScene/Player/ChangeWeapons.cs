using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeWeapons : MonoBehaviour
{
    [SerializeField]
    public GameObject[] weapons; // Массив объектов-оружий
    private int currentWeaponIndex = 0; // Индекс текущего выбранного оружия 
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            SwitchWeapon();
        }
    }
    void SwitchWeapon()
    {
        // Отключаем текущее оружие
        weapons[currentWeaponIndex].SetActive(false);

        // Увеличиваем индекс текущего оружия
        currentWeaponIndex++;

        // Если индекс превышает количество доступных оружий, переходим к первому оружию
        if (currentWeaponIndex >= weapons.Length)
        {
            currentWeaponIndex = 0;
        }

        // Активируем новое оружие
        weapons[currentWeaponIndex].SetActive(true);
    }
}
