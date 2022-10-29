namespace Core.Characters.Player.Behavior
{
    public class RunningState : StatePlayer
    {
        public override void Start()
        {
            Animation.StartRunning();
        }
        public override void Update()
        {
            if (Movement.IsMove)
            {
                Animation.Running();
                Movement.Move();
            }
            else
            {
                BehaviourSystem.SetState(CreateInstance<IdleState>());
            }
        }
        public override void End()
        {
            Animation.StopRunning();
        }
    }
}
