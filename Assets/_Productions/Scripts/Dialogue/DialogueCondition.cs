using RootMotion;

namespace JustMonika.VR
{
    [System.Serializable]
    public class DialogueCondition
    {
        public DialogueRulesType rulesType;
        
        [ShowIf("rulesType", DialogueRulesType.HasVariable)]
        public string variableName;
        
        [ShowIf("rulesType", DialogueRulesType.AffectionLevel)]
        public MonikaAffection minimumAffectionLevel;

        [ShowIf("rulesType", DialogueRulesType.DateRange)]
        public string startDate = "01-01-1999";
        [ShowIf("rulesType", DialogueRulesType.DateRange)]
        public string endDate = "30-12-2999";
    }
}