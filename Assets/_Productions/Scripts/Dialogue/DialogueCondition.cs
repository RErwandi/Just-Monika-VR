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
        public int day = 1;
        [ShowIf("rulesType", DialogueRulesType.DateRange)]
        public int month = 1;
        [ShowIf("rulesType", DialogueRulesType.DateRange)]
        public bool useYear;
        [ShowIf("rulesType", DialogueRulesType.DateRange)]
        public int year = 2022;
    }
}