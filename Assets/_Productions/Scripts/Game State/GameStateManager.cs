using GameLokal.Toolkit;

namespace JustMonika.VR
{
    public class GameStateManager : Singleton<GameStateManager>
    {
        protected override bool ShouldNotDestroyOnLoad()
        {
            return false;
        }

        private StateMachine<GameStateMachine> gamesState;

        private void Start()
        {
            gamesState = new StateMachine<GameStateMachine>(gameObject, true);
            Invoke("FirstState", 3f);
        }

        private void FirstState()
        {
            ChangeState(GameStateMachine.Greeting);
        }
        
        public static void ChangeState(GameStateMachine newState)
        {
            Instance.gamesState.ChangeState(newState);
        }
    }
}