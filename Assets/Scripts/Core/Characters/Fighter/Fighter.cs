using Core.Characters._Base;
using Core.Characters.Fighter.Fighting;
using Core.Characters.Fighter.Health;
using Core.Characters.Fighter.Level;
using DG.Tweening;
using NaughtyAttributes;
using UnityEngine;

namespace Core.Characters.Fighter
{
    public class Fighter : Character
    {
        [SerializeField] private FighterMovement _movement;
        [SerializeField] private AnimationFighter _animation;
        [SerializeField] private LevelFighter _level;
        [SerializeField] private FightingComponent _fightingComponent;
        [SerializeField] private HealthComponent _healthComponent;
        public FighterMovement Movement => _movement;
        public AnimationFighter Animation => _animation;
        public LevelFighter Level => _level;
        public FightingComponent FightingComponent => _fightingComponent;
        public HealthComponent HealthComponent => _healthComponent;
        [ShowNativeProperty] public bool IsFormation { get; private set; }

        public Tween Formation(Vector3 position)
        {
            IsFormation = true;
            _movement.IsStopped = true;
            return _movement.SetPosition(position);
        }

        public void Deformation()
        {
            IsFormation = false;
            _movement.IsStopped = false;
            transform.parent = null;
        }
    }
}