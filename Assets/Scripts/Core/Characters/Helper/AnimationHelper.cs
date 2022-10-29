using Core.Characters._Base;
using UnityEngine;

namespace Core.Characters.Helper
{
    public class AnimationHelper : MonoBehaviour
    {
        [SerializeField] private Animator _animator;
        private readonly int _runningNameId = Animator.StringToHash("IsRunning");
        private bool _isRunning;
        public bool IsRunning
        {
            get => _isRunning;
            set
            {
                if (value != _isRunning)
                {
                    _isRunning = value;
                    _animator.SetBool(_runningNameId, value);
                }
            }
        }
    }
}