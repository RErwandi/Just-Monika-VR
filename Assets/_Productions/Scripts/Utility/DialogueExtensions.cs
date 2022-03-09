using System.Linq;

namespace JustMonika.VR
{
    public static class DialogueExtensions
    {
        public static bool HasValidCondition(this BaseDialogueData dialogue)
        {
            foreach (var condition in dialogue.conditional)
            {
                switch (condition.rulesType)
                {
                    case DialogueRulesType.HasVariable when !IsHasVariableValid(condition.variableName):
                    case DialogueRulesType.AffectionLevel when !IsAffectionValid(condition.minimumAffectionLevel):
                    case DialogueRulesType.DateRange when !IsDateRangeValid(condition.day, condition.month, condition.year, condition.useYear):
                        return false;
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

        private static bool IsDateRangeValid(int day, int month, int year, bool useYear = false)
        {
            if (useYear)
            {
                if (Blackboard.Time.Day == day && Blackboard.Time.Month == month && Blackboard.Time.Year == year)
                    return true;
            }
            else
            {
                if (Blackboard.Time.Day == day && Blackboard.Time.Month == month)
                    return true;
            }
            

            return false;
        }
    }
}