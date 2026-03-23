using System.Collections.Generic;
using BlockSurvive.Interfaces;
using BlockSurvive.Weapons;
using UnityEngine;
using Zenject;


namespace BlockSurvive.Entities.Player
{
    public class WeaponController : MonoBehaviour
    {

        private List<IWeapon> _weapons = new List<IWeapon>();
        private WeaponFactory _weaponFactory;
        private PlayerStats _playerStats;

        [Inject]
        public void Construct(WeaponFactory weaponFactory, PlayerStats playerStats)
        {
            _weaponFactory = weaponFactory;
            _playerStats = playerStats;
        }

        private void Start()
        {
            _weapons.Add(_weaponFactory.CreateWeapon(WeaponType.Daggers));
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