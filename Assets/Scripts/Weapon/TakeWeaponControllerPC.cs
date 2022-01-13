using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Weapon;

public class TakeWeaponControllerPC : MonoBehaviour
{
    public WeaponsController WeaponsController;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            WeaponsController.SwitchWeapon(0);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            WeaponsController.SwitchWeapon(1);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            WeaponsController.SwitchWeapon(2);
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            WeaponsController.SwitchWeapon(3);
        }
    }
}
