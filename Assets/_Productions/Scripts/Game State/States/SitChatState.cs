using System.Collections.Generic;
using System.Linq;
using GameLokal.Toolkit;
using Sirenix.OdinInspector;

namespace JustMonika.VR
{
    public class SitChatState : BaseState
    {
        public Marker playerSitPosition;
        public Marker monikaSitPosition;
        [ShowInInspector, ReadOnly]
        private List<DialogueSetting> topicsQueue = new List<DialogueSetting>();
        
        protected override void OnStateEnter()
        {
            QueueTopics();
            Invoke("StartRandomTopic", Blackboard.GamePersistence.RandomTopicInterval);
            
            EnterState();
        }

        protected override void OnStateExit()
        {
            CancelInvoke("StartRandomTopic");
            
            ExitState();
        }

        private void EnterState()
        {
            Player.Instance.Mount();
            Player.Instance.DisableCameraMovement();
            Player.Instance.DisableMovement();
            Player.Instance.Teleport(playerSitPosition);
            Player.Instance.Crouch();
            Player.Instance.FaceFrontCamera();
            
            Monika.Mount();
            Monika.Teleport(monikaSitPosition);
            Monika.Instance.SetAnim("Sit", true);
        }

        private void ExitState()
        {
            Player.Instance.UnMount();
            Player.Instance.EnableCameraMovement();
            Player.Instance.EnableMovement();
            Player.Instance.UnCrouch();

            Monika.UnMount();
            Monika.Instance.SetAnim("Sit", false);
        }
        
        private void QueueTopics()
        {
            topicsQueue = Database.Instance.topics.ToList();
            topicsQueue.Shuffle();
            topicsQueue.Sort((a, b) => a.priority.CompareTo(b.priority));

            var iToBeDeleted = new List<int>();
            for (int i = 0; i < topicsQueue.Count; i++)
            {
                var topic = topicsQueue[i];

                if (!topic.HasValidCondition())
                {
                    iToBeDeleted.Add(i);
                } /*else if (!Blackboard.GamePersistence.RepeatTopics &&
                           Blackboard.GamePersistence.VisitedTopics.Contains(topic.name))
                {
                    iToBeDeleted.Add(i);
                }*/
            }

            foreach (var i in iToBeDeleted)
            {
                topicsQueue.RemoveAt(i);
            }
        }
        
        private void StartRandomTopic()
        {
            var chosenTopic = topicsQueue[0];
            StartTopicDialogue(chosenTopic);
        }
        
        private void StartTopicDialogue(DialogueSetting dialogueSetting)
        {
            Blackboard.GamePersistence.AddVisitedTopic(dialogueSetting.name);
            Blackboard.DialogueSystem.StartDialogue(dialogueSetting.name, OnDialogueFinish);
            topicsQueue.RemoveAt(0);
        }
        
        private void OnDialogueFinish()
        {
            Invoke("StartRandomTopic", Blackboard.GamePersistence.RandomTopicInterval);
        }
    }
}