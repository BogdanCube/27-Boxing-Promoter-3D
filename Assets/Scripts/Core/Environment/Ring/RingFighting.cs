using System;
using System.Threading.Tasks;
using Core.Characters.Fighter.Fighting;
using Core.Characters.Fighter.Fighting.Data;
using NaughtyAttributes;
using Toolkit.Extensions;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Core.Environment.Ring
{
    public class RingFighting : MonoBehaviour
    {
        [SerializeField] private float _pauseTime;
        [Expandable][SerializeField] private FightingData _fightingData;
        [SerializeField] private ParticleSystem _particle;
        [SerializeField] private FightingComponent _firstFighter;
        [SerializeField] private FightingComponent _secondFighter;
        private TemplateFighting _currentTemplate;
        public event Action OnAttack;
        public event Action OnWin;
        public async Task StartCycle(FightingComponent firstFighter,FightingComponent secondFighter)
        {
            _firstFighter = firstFighter;
            _secondFighter = secondFighter;
            
            while (true)
            {
                if (_firstFighter.IsLive && _secondFighter.IsLive)
                {
                    await Fighting();
                }
                else
                {
                    _particle.Activate();
                    OnWin?.Invoke();
                    break;
                }
            }
          
        }
        [Button]
        private async Task TestFighting()
        {
            _currentTemplate = _fightingData.Templates[0];
            
            await Attack(_firstFighter);
            await Hit(_secondFighter);
            await Attack(_secondFighter);
            await Hit(_firstFighter);
        }
        private async Task Fighting()
        {
            _currentTemplate = _fightingData.Templates.RandomItem();
            if (GetChance() > Random.value)
            {
                await Attack(_firstFighter);
                await Hit(_secondFighter,_firstFighter.Damage);
            }
            else
            {
                await Attack(_secondFighter);
                await Hit(_firstFighter,_secondFighter.Damage);
            }
        }
        private async Task Attack(FightingComponent fighter)
        {
            await Task.Delay(TimeSpan.FromSeconds(_pauseTime));
            var attackClip = _currentTemplate.AttackClip;
            var time = attackClip.length - _currentTemplate.AttackDelay;
            fighter.Attack(attackClip);
            await Task.Delay(TimeSpan.FromSeconds(time));
            OnAttack?.Invoke();
            fighter.NoState();
        }

        private async Task Hit(FightingComponent fighter,int damage = 0)
        {
            await Task.Delay(TimeSpan.FromSeconds(_pauseTime));
            var hitClip = _currentTemplate.HitClip;
            var time = hitClip.length - _currentTemplate.HitDelay;
            fighter.Hit(hitClip,damage);
            await Task.Delay(TimeSpan.FromSeconds(time));
            fighter.NoState();
        }

        public void DeathSecondFighter()
        {
            _secondFighter.Death();
        }
        private float GetChance()
        {
            var firstLevel = _firstFighter.Level;
            var secondLevel = _secondFighter.Level;

            if (firstLevel > secondLevel)
            {
                return 0.7f;
            }
            else if (firstLevel < secondLevel)
            {
                return 0.3f;
            }
            else
            {
                return 0.5f;
            }
        }

    }
}