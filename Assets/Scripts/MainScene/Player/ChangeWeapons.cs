using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeWeapons : MonoBehaviour
{
    [SerializeField]
    public GameObject[] weapons; // ������ ��������-������
    private int currentWeaponIndex = 0; // ������ �������� ���������� ������ 
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            SwitchWeapon();
        }
    }
    void SwitchWeapon()
    {
        // ��������� ������� ������
        weapons[currentWeaponIndex].SetActive(false);

        // ����������� ������ �������� ������
        currentWeaponIndex++;

        // ���� ������ ��������� ���������� ��������� ������, ��������� � ������� ������
        if (currentWeaponIndex >= weapons.Length)
        {
            currentWeaponIndex = 0;
        }

        // ���������� ����� ������
        weapons[currentWeaponIndex].SetActive(true);
    }
}
