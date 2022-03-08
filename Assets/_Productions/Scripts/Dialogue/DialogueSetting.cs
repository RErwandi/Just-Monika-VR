using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

namespace JustMonika.VR
{
    public class DialogueSetting : BaseDialogueData
    {
        [Title("Dialogue Settings")]
        // Name of text shown in the button that will trigger this topic.
        public string promptName;
        // Category of this dialogue
        [ValueDropdown("AvailableExpression")]
        public string category;
        private List<string> AvailableExpression => DialogueConfig.Instance.GetAvailableCategory;
        // TRUE: will allow this topic to be shown randomly where Monika initiates the conversation.
        public bool random;
        // TRUE: will allow this topic to appear in the Unseen menu as well as they "Hey Monika" menu
        // This should be used for topics where player initiates the conversation.
        public bool pool;
    }
}