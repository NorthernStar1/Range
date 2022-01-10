using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Weapon
{
    [Serializable]
    public struct WeaponSlot
    {
        public KeyCode ActivateKey;

        public IWeapon WeaponInstance;
    }
    public class WeaponsController
    {
        private IWeapon _currentWeapon;
        private Camera _camera;
        public static List<IWeapon> Weapons { get; set; }

        public WeaponsController(Camera camera)
        {
            this._camera = camera;
        }

        private void Start()
        {
            _currentWeapon = Weapons[0];
        }
        private void Update()
        {

        }
    }

}

