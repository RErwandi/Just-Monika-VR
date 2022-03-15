using UnityEngine;

namespace JustMonika.VR
{
    public class ChangeStateInstructions : MonoBehaviour
    {
        public GameStateMachine targetState;

        public void Run()
        {
            GameStateManager.ChangeState(targetState);
        }
    }
}