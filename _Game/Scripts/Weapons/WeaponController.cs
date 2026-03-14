using System.Collections.Generic;
using BlockSurvive.Interfaces;
using UnityEngine;
using Zenject;


namespace BlockSurvive.Entities.Player
{
    public class WeaponController : MonoBehaviour
    {

        private List<IWeapon> _weapons;

        [Inject]
        public void Construct(List<IWeapon> weapons)
        {
            _weapons = weapons;

        }


        private void Update()
        {
            foreach (var weapon in _weapons)
                weapon.Tick();
        }

        public void AddWeapon(IWeapon weapon)
        {
            _weapons.Add(weapon);
        }

    }
}