using System;
using System.Threading.Tasks;
using Core.Characters.Fighter.Health;
using Core.Characters.Fighter.Level;
using UnityEngine;

namespace Core.Characters.Fighter.Fighting
{
    public enum FightingState
    {
        NoState,Attack,Hit
    }
    public class FightingComponent : MonoBehaviour
    {
        [SerializeField] private LevelFighter _level;
        [SerializeField] private HealthComponent _healthComponent;
        [SerializeField] private AnimationFighter _animation;
        [SerializeField] private FightingState _state = FightingState.NoState;
        public FightingState State => _state;
        public bool IsLive => _healthComponent.IsDeath == false;
        public int Level => _level.CurrentLevel;
        public int Damage => _healthComponent.Damage;
        
        public void Attack(AnimationClip clip)
        {
            if (IsLive == false) return;
            
            _animation.SetFightingClip(clip);
            _state = FightingState.Attack;
        }

        public void Hit(AnimationClip clip, int damage)
        {         
            if (IsLive == false) return;

            _animation.SetHitClip(clip);
            _state = FightingState.Hit;
            _healthComponent.Hit(damage);
        }
        public void NoState()
        {
            _state = FightingState.NoState;
        }

        public void Death()
        {
            if(_healthComponent.IsDeath) return;
            _healthComponent.Death();
        }
    }
}