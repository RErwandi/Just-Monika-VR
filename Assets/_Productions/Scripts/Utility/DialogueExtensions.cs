using System;
using System.Linq;
using UnityEngine;

namespace JustMonika.VR
{
    public static class DialogueExtensions
    {
        public static bool IsValidCondition(this BaseDialogueData dialogue)
        {
            foreach (var condition in dialogue.conditional)
            {
                switch (condition.rulesType)
                {
                    case DialogueRulesType.HasVariable when !IsHasVariableValid(condition.variableName):
                    case DialogueRulesType.AffectionLevel when !IsAffectionValid(condition.minimumAffectionLevel):
                        return false;
                    case DialogueRulesType.DateRange:
                        break;
                }
            }

            return true;
        }

        private static bool IsHasVariableValid(string variableName)
        {
            Blackboard.VariableStorage.TryGetValue(variableName, out string stringVar);
            return !string.IsNullOrEmpty(stringVar);
        }

        private static bool IsAffectionValid(MonikaAffection affection)
        {
            float neededAffection = 0;
            foreach (var affectionSetting in GameConfig.Instance.affectionSettings.Where(affectionSetting => affectionSetting.affection == affection))
            {
                neededAffection = affectionSetting.reqAffection;
            }

            return Blackboard.GamePersistence.Affection >= neededAffection;
        }
    }
}