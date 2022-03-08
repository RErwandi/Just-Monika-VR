using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

namespace JustMonika.VR
{
    public class BaseDialogueData : ScriptableObject
    {
        // This topic will only be allowed if every variable in conditional is met.
        [Title("Condition")]
        public List<DialogueCondition> conditional = new List<DialogueCondition>();
        // 0 is default priority, if you want this topic to be on the top of queue, put higher number than 0
        public int priority = 1000;
    }
}