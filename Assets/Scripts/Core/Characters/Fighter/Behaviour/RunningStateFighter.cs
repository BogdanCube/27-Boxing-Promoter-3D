namespace Core.Characters.Fighter.Behaviour
{
    public class RunningStateFighter : StateFighter
    {
        public override void Start()
        {
            Animation.StartRunning(0.1f);
        }
        protected override void UpdateAction()
        {
            if (MovementController.IsMove)
            {
                if (MovementController.IsMoving)
                {
                    Animation.Running();
                }
                else
                {
                    BehaviourSystem.SetState(CreateInstance<IdleStateFighter>());
                }
                MovementController.Move();
            }
            else
            {
                BehaviourSystem.SetState(CreateInstance<IdleStateFighter>());
            }
        }
        public override void End()
        {
            Animation.StopRunning();
        }
    }
}