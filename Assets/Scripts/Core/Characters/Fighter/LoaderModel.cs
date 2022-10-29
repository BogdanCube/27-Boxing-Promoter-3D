using System;
using Core.Characters.Fighter.Level;
using Toolkit.Extensions;
using UnityEngine;

namespace Core.Characters.Fighter
{
    public class LoaderModel : MonoBehaviour
    {
        [SerializeField] private AnimationFighter _animation;
        [SerializeField] private Animator _firstAnimator;
        [SerializeField] private Animator _secondtAnimator;
        [SerializeField] private LevelFighter _level;

        private void OnEnable()
        {
            _level.OnUpdateBar += SetModel;
        }

        private void OnDisable()
        {
            _level.OnUpdateBar += SetModel;
        }
        private void SetModel(int level, Color color)
        {
            if (_level.CurrentLevel > 0)
            {
                _animation.SetAnimator(_firstAnimator);
                _secondtAnimator.Deactivate();
            }
            else
            {
                _animation.SetAnimator(_secondtAnimator);
                _firstAnimator.Deactivate();
            }

        }
    }
}