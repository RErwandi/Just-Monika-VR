using System;
using System.Collections.Generic;
using System.Linq;
using GameLokal.Toolkit;
using Sirenix.OdinInspector;
using UnityEngine;
using Random = UnityEngine.Random;

namespace JustMonika.VR
{
    public class Classroom : MonoBehaviour
    {
        [AssetList(Path = "/_Databases/Dialogues/Topics", AutoPopulate = true)]
        public List<DialogueSetting> topics = new List<DialogueSetting>();

        [ShowInInspector, ReadOnly]
        private List<DialogueSetting> topicsQueue = new List<DialogueSetting>();

        private void Start()
        {
            QueueTopics();
            Invoke("StartRandomTopic", Blackboard.GamePersistence.RandomTopicInterval);
        }

        private void QueueTopics()
        {
            topicsQueue = topics.ToList();
            topicsQueue.Shuffle();
            topicsQueue.Sort((a, b) => b.priority.CompareTo(a.priority));

            var iToBeDeleted = new List<int>();
            
            if (!Blackboard.GamePersistence.RepeatTopics)
            {
                for(int i = 0; i < topicsQueue.Count; i++)
                {
                    var topic = topicsQueue[i];
                    if (Blackboard.GamePersistence.VisitedTopics.Contains(topic.name))
                    {
                        iToBeDeleted.Add(i);
                    }
                }
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
            DialogueSystem.Instance.StartDialogue(dialogueSetting.name, OnDialogueFinish);
            topicsQueue.RemoveAt(0);
        }

        private void OnDialogueFinish()
        {
            Invoke("StartRandomTopic", Blackboard.GamePersistence.RandomTopicInterval);
        }

        [Button]
        public DialogueSetting GetRandomTopics()
        {
            DialogueSetting chosenTopic;
            do
            {
                var r = Random.Range(0, topics.Count);
                chosenTopic = topics[r];
            } while (!ConditionApproved(chosenTopic));

            Debug.Log($"Chosen topic is {chosenTopic.name}");
            return chosenTopic;
        }

        private bool ConditionApproved(DialogueSetting dialogue)
        {
            foreach (var condition in dialogue.conditional)
            {
                // Variable Condition Check
                if (condition.rulesType == DialogueRulesType.HasVariable)
                {
                    if (!Blackboard.VariableStorage.Contains(condition.variableName))
                    {
                        return false;
                    }
                }

                // Affection Condition Check
                if (condition.rulesType == DialogueRulesType.AffectionLevel)
                {
                    float requiredAffection = 0;
                    foreach (var affectionSetting in GameConfig.Instance.affectionSettings)
                    {
                        if (affectionSetting.affection == condition.minimumAffectionLevel)
                        {
                            requiredAffection = affectionSetting.reqAffection;
                        }
                    }

                    if (Blackboard.GamePersistence.Affection < requiredAffection)
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}