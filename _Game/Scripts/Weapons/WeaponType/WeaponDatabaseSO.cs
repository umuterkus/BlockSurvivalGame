using System.Collections.Generic;
using UnityEngine;

namespace BlockSurvive.Weapons
{
    [CreateAssetMenu(menuName = "Weapons/Weapon Database")]
    public class WeaponDatabase : ScriptableObject
    {
        public List<WeaponDataSO> weapons;
    }
}