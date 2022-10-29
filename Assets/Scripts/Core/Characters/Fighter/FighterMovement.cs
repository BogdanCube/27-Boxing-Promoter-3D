using Core.Characters._Base;
using Core.Components;
using DG.Tweening;
using NaughtyAttributes;
using Toolkit.Extensions;
using UnityEngine;

namespace Core.Characters.Fighter
{
    public class FighterMovement : MovementController
    {
        private Vector3 _currentPosition;
        [ShowNonSerializedField] private bool _isFormation;
        public override bool IsMove => IsStopped == false || _isFormation;
        public bool IsMoving => _navMeshAgent.velocity.magnitude > 0f || _isFormation;
        public override void Move()
        {
            if (IsStopped == false && _currentPosition != Vector3.zero)
            {
                _navMeshAgent.SetDestination(_currentPosition);
            }
        }
        
        public void SetToPlayer(Vector3 position)
        {
            _currentPosition = position;
        }

        public Tween SetPosition(Vector3 position)
        {
            transform.LookAt(position);

            return transform.DOMove(position, _speed / 2f).SetSpeedBased()
                .SetEase(Ease.Linear)
                .OnUpdate(() => _isFormation = true)
                .OnComplete(() => _isFormation = false);
        }
    }
}