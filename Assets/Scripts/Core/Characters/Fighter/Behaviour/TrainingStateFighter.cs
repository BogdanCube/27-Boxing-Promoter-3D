namespace Core.Characters.Fighter.Behaviour
{
    public class TrainingStateFighter : StateFighter
    {
        public override void Start()
        {
            Animation.IsTraining = true;
        }
        public override void Update()
        {
            if (Level.IsTraining) return;
            
            if (MovementController.IsMove)
            {
                BehaviourSystem.SetState(CreateInstance<RunningStateFighter>());
            }
            else
            {
                BehaviourSystem.SetState(CreateInstance<IdleStateFighter>());
            }
        }
        public override void End()
        {
            Animation.IsTraining = false;
        }
    }
}