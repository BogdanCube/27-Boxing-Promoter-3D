using System;
using Core.Characters._Base;
using DG.Tweening;
using Toolkit.Extensions;
using UnityEngine;

namespace Core.Characters.Helper
{
    public class HelperMovement : UpdaterPosition
    {
        private Vector3 _currentPosition;
        private Vector3 _startPosition;
        private Tween _tween;
        public bool IsPlaceStart => transform.DistanceToTarget(_startPosition) < 0.1;
        public override bool IsMove => transform.DistanceToTarget(_currentPosition) < 0.1;
        private void Start()
        {
            _startPosition = transform.position;
        }

        protected override void MoveLogic()
        {
            if (IsStopped == false && _currentPosition != Vector3.zero)
            {
                _navMeshAgent.SetDestination(_currentPosition);
            }
        }
        public void SetPosition(Transform target)
        {
            SetPosition(target.position);
        }
        public void SetStartPosition()
        {
            SetPosition(_startPosition);
        }
        private void SetPosition(Vector3 position)
        {
            _currentPosition = position;
        }
    }
}