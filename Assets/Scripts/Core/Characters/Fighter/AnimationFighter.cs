using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Characters._Base;
using Core.Characters.Fighter.Fighting.Data;
using Core.Characters.Fighter.Level;
using Core.Characters.Fighter.Level.Data;
using Core.Components;
using Core.Environment.TrainingZone;
using DG.Tweening;
using NaughtyAttributes;
using UnityEngine;
using UnityEngine.AI;

namespace Core.Characters.Fighter
{
    public class AnimationFighter : AnimationStateController
    {
        private const string _trainingNameId = "Training";
        private const string _attackNameId = "Attack";
        private const string _hitNameId = "Hit";
        private readonly int _deathNameId = Animator.StringToHash("Death");
        private bool _isTraining;

        public bool IsTraining
        {
            get => _isTraining;
            set
            {
                if (value == _isTraining) return;
                _isTraining = value;
                _animator.SetBool(_trainingNameId , _isTraining);
            }
        }
        public void SetAttack()
        {
            _animator.SetTrigger(_attackNameId);
        }
        public void SetHit()
        {
            _animator.SetTrigger(_hitNameId);
        }
        public void SetDeath()
        {
            _animator.SetTrigger(_deathNameId);
        }
        public void SetFightingClip(AnimationClip clip)
        {
            SetAnimationClip(clip, _attackNameId);
        }
        public void SetHitClip(AnimationClip clip)
        {
            SetAnimationClip(clip, _hitNameId);
        }
        public void SetTrainingClip(AnimationClip clip)
        {
            if (clip)
            {
                SetAnimationClip(clip, _trainingNameId);
            }
        }
    }
}