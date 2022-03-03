using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

namespace JustMonika.VR
{
    public class Classroom : MonoBehaviour
    {
        [AssetList(Path = "/_Databases/Dialogues/Topics", AutoPopulate = true)]
        public List<DialogueSetting> randomTopics = new List<DialogueSetting>();

        [Button]
        public DialogueSetting GetRandomTopics()
        {
            DialogueSetting chosenTopic;
            do
            {
                var r = Random.Range(0, randomTopics.Count);
                chosenTopic = randomTopics[r];
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