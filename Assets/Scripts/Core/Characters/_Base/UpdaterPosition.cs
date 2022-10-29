using System;
using UnityEngine;

namespace Core.Characters._Base
{
    public abstract class UpdaterPosition : MovementController
    {
        [SerializeField] private Transform _centerDetachment;
        private Vector3 _lastPose;
        public event Action<Vector3> OnChangePosition;
        public override bool IsMove { get; }
        
        private void OnEnable()
        {
            _lastPose = transform.position;
        }
        public override void Move()
        {
            UpdatePosition();
            MoveLogic();
        }
        protected abstract void MoveLogic();
        private void UpdatePosition()
        {
            if (IsStopped) return;
            
            if (transform.position != _lastPose)
            {
                OnChangePosition?.Invoke(_centerDetachment.position);
            }

            _lastPose = transform.position;
        }
    }
}