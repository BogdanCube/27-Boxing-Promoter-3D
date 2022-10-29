using Core.Characters.Fighter.Fighting;

namespace Core.Characters.Fighter.Behaviour
{
    public class HitStateFighter : StateFighter
    {
        public override void Start()
        {
            Animation.SetHit();
        }
        public override void Update()
        {
            if (HealthComponent.IsDeath == false)
            {
                if (FightingComponent.State == FightingState.NoState)
                {
                    BehaviourSystem.SetState(CreateInstance<IdleStateFighter>());
                }
            }
            else
            {
                BehaviourSystem.SetState(CreateInstance<DeathStateFighter>());
            }
        }
    }
}