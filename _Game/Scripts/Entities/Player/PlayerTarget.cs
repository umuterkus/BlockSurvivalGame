using BlockSurvive.Interfaces;
using UnityEngine;

namespace BlockSurvive.Entities.Player
{
    public class PlayerTarget : MonoBehaviour, ITarget
    {
        public Transform Transform => transform;
    }
}
