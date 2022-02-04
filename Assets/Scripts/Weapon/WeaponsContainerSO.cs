using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "WeaponsContainer", menuName = "Weapons/Container", order = 0)]
public class WeaponsContainerSO : ScriptableObject
{
    [Tooltip("Objects in this list are must contain component which implements interface IWeapon")]
    public List<GameObject> WeaponPrefabs;
}
