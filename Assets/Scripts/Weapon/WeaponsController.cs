using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Weapon
{
    public class WeaponsController : MonoBehaviour
    {
        public Transform WeaponsRoot;
        public WeaponsContainerSO ContainerSO;
        public List<IWeapon> WeaponsInstances;
        public IWeapon CurrentWeapon { get; private set; }

        private void Start()
        {
            Initialize();
            SwitchWeapon(0);
        }
      
        public void Initialize()
        {
            WeaponsInstances = new List<IWeapon>();

            foreach(var preFab in ContainerSO.WeaponPrefabs)
            {
                var go = Instantiate(preFab, WeaponsRoot);
                var weapon = go.GetComponent<IWeapon>();
                weapon.Initialize();
                weapon.Remove();
                WeaponsInstances.Add(weapon);
            }
            CurrentWeapon = WeaponsInstances[0];
        }
        public void SwitchWeapon(int index)
        {
            CurrentWeapon?.Remove();
            CurrentWeapon = WeaponsInstances[index];
            CurrentWeapon?.Take();
        }
    }

}

