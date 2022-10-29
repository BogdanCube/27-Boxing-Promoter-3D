using UnityEngine;

namespace Core.Characters.Fighter
{
    public class StopperFighter : MonoBehaviour
    {
        [SerializeField] private Fighter _fighter;
        [SerializeField] private FighterMovement _movement;
        private void OnTriggerEnter(Collider other)
        {
            if (_fighter.IsFormation == false && other.TryGetComponent(out Player.Player player))
            {
                _movement.IsStopped = true;
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (_fighter.IsFormation == false && other.TryGetComponent(out Player.Player player))
            {
                _movement.IsStopped = false;
            }
        }
    }
}