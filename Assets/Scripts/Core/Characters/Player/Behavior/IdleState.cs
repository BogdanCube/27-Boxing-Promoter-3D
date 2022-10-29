namespace Core.Characters.Player.Behavior
{
    public class IdleState : StatePlayer
    {
        public override void Start()
        {
            Animation.StopRunning();
        }
        public override void Update()
        {
            if (Movement.IsMove)
            {
                BehaviourSystem.SetState(CreateInstance<RunningState>());
            }
        }
    }
}