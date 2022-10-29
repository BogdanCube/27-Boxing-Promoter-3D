using System.Collections.Generic;
using DG.Tweening;
using NaughtyAttributes;
using Toolkit.Extensions;
using UnityEngine;

namespace Core.Characters._Base
{
    public class AnimationStateController : MonoBehaviour
    {
        [SerializeField] private protected Animator _animator;
        [SerializeField] private float _startRunning;
        private readonly int _runningNameId = Animator.StringToHash("Running");
        private float _speed;
        [ShowNonSerializedField]private float _currentVelocity;
        public void StartRunning(float velocity = 0.25f)
        {
            _currentVelocity = velocity;
            DOTween.To(() => _currentVelocity, x => _currentVelocity = x, 1, _startRunning);
        }

        public void Running()
        {
            _animator.SetFloat(_runningNameId, _currentVelocity);
        }
        public void StopRunning()
        {
            _currentVelocity = 0;
            _animator.SetFloat(_runningNameId, 0);
        }

        public void SetSpeed(float speed)
        {
            _speed = speed;
            _animator.speed = _speed;
        }
        protected void SetAnimationClip(AnimationClip clip, string nameId)
        {
            if (_animator == null) return;
            
            var animatorOverride = new AnimatorOverrideController(_animator.runtimeAnimatorController);
            
            var clips = new List<KeyValuePair<AnimationClip, AnimationClip>>();
            foreach (var currentClip in animatorOverride.animationClips)
            {
                var addingClip = currentClip.name.Contains(nameId) ? clip : currentClip;
                clips.Add(new KeyValuePair<AnimationClip, AnimationClip>(currentClip, addingClip));
            }
            animatorOverride.ApplyOverrides(clips);
            _animator.runtimeAnimatorController = animatorOverride;
        }
        
        public void SetAnimator(Animator animator)
        {
            _animator = animator;
            _animator.Activate();
        }
    }
}