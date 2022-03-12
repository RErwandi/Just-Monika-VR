using GameLokal.Toolkit;
using UnityEngine;

namespace JustMonika.VR
{
    public class BaseState : MonoBehaviour, IEventListener<StateChangeEvent<GameStateMachine>>
    {
        public GameStateMachine state;

        protected virtual void OnEnable()
        {
            EventManager.AddListener(this);
        }

        protected virtual void OnDisable()
        {
            EventManager.RemoveListener(this);
        }

        protected virtual void OnStateEnter()
        {
            Debug.Log($"Entering state {gameObject.name}");
        }

        protected virtual void OnStateExit()
        {

        }

        public void OnEvent(StateChangeEvent<GameStateMachine> e)
        {
            if (e.newState == state)
            {
                OnStateEnter();
            }

            if (e.previousState == state)
            {
                OnStateExit();
            }
        }
    }
}