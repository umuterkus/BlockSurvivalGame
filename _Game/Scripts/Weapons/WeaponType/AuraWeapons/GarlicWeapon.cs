using BlockSurvive.Entities.Player;
using BlockSurvive.Interfaces;
using System.Collections.Generic;
using UnityEngine;

namespace BlockSurvive.Weapons
{
    public class GarlicWeapon : IWeapon
    {
        private readonly ITarget _target;
        private readonly PlayerStats _playerStats;
        private readonly int _damage;
        private readonly float _cooldown;
        private readonly float _radius;
        private readonly List<Collider2D> _hitBuffer = new List<Collider2D>();
        private readonly ContactFilter2D _filter;
        private float _timer = 0;

        public GarlicWeapon(AuraWeaponData data, PlayerStats playerStats, ITarget target)
        {
            _target = target;
            _playerStats = playerStats;
            _damage = data.damage;
            _cooldown = data.cooldown;
            _radius = data.radius;

            _filter = new ContactFilter2D();
            _filter.SetLayerMask(LayerMask.GetMask("Enemy", "Destructable"));
            _filter.useLayerMask = true;
        }

        public void Tick()
        {
            _timer += Time.deltaTime;
            var finalCooldown = Mathf.Max(0.1f, _cooldown * _playerStats.WeaponCooldown);
            if (_timer > finalCooldown)
            {
                var finalDamage = (int)(_damage * _playerStats.DamageMultiplier);
                Physics2D.OverlapCircle(_target.Transform.position, _radius, _filter, _hitBuffer);
                foreach (var hit in _hitBuffer)
                {
                    if (hit == null) continue;
                    if (hit.TryGetComponent<IDamageable>(out var damageable))
                        damageable.TakeDamage(finalDamage);
                }
                _timer = 0;
            }
        }
    }
}