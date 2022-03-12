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
        }

        private void OnGreetingFinish()
        {
            Debug.Log($"Greeting finished");
        }
    }
}