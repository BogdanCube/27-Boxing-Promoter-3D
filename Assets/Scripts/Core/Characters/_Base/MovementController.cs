using NaughtyAttributes;
using NTC.Global.Cache;
using UnityEngine;
using UnityEngine.AI;

namespace Core.Characters._Base
{
    public class MovementController : NightCache
    {
        [SerializeField] private protected float _speed;
        [SerializeField] private protected NavMeshAgent _navMeshAgent;
        private bool _isStopped;
        public virtual bool IsMove { get; }
        public bool IsStopped
        {
            get => _isStopped;
            set
            {
                if (value != _isStopped)
                {
                    _isStopped = value;
                    _navMeshAgent.enabled = !_isStopped;
                }
            }
        }
        private void Awake()
        {
            _navMeshAgent.speed = _speed;
        }

        public virtual void Move() {}
        public void SetSpawn(Vector3 position)
        {
            IsStopped = true;
            _navMeshAgent.Warp(position);
            IsStopped = false;
        }
    }
}