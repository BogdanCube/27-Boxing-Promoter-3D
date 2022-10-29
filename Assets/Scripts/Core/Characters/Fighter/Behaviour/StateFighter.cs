using Core.Characters._Base;
using Core.Characters.Fighter.Fighting;
using Core.Characters.Fighter.Health;
using Core.Characters.Fighter.Level;
using Core.Components;
using UnityEngine;

namespace Core.Characters.Fighter.Behaviour
{
    public class StateFighter : ScriptableObject,IState 
    {
        public BehaviourFighter BehaviourSystem { get; set; }
        private Fighter Fighter => BehaviourSystem.Fighter;
        protected FighterMovement MovementController => Fighter.Movement;
        protected AnimationFighter Animation => Fighter.Animation;
        protected LevelFighter Level => Fighter.Level;
        protected FightingComponent FightingComponent => Fighter.FightingComponent;
        protected HealthComponent HealthComponent => Fighter.HealthComponent;
        
        public virtual void Start() { }

        public virtual void Update()
        {
            if (HealthComponent.IsDeath == false)
            {
                if (FightingComponent.State != FightingState.NoState)
                {
                    StateFighter fightingState = FightingComponent.State == FightingState.Attack
                            ? CreateInstance<AttackStateFighter>() : CreateInstance<HitStateFighter>();
                
                    BehaviourSystem.SetState(fightingState);
                }
                else
                {
                    if (Level.IsTraining)
                    {
                        BehaviourSystem.SetTrainingState();
                    }
                    else
                    {
                        UpdateAction();
                    }
                }
            }
            else
            {
                BehaviourSystem.SetState(CreateInstance<DeathStateFighter>());
            }
         
        }
        
        public virtual void End() { }
        protected virtual void UpdateAction() { }
    }
}