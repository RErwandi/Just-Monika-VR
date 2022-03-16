using UnityEngine;

namespace JustMonika.VR
{
    public class GreetingState : BaseState
    {
        protected override void OnStateEnter()
        {
            base.OnStateEnter();

            var randomGreeting = Database.GetRandomGreeting();
            Blackboard.DialogueSystem.StartDialogue(randomGreeting.name, OnGreetingFinish);
            Player.Instance.DisableMovement();
        }

        private void OnGreetingFinish()
        {
            Debug.Log($"Greeting finished");
            Player.Instance.EnableMovement();
        }
    }
}