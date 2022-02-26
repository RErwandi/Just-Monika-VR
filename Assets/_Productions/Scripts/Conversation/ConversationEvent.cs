using Sirenix.OdinInspector;

namespace JustMonika.VR
{
    [System.Serializable]
    public class ConversationEvent
    {
        public ConversationType type;
        
        // Dialogue
        [ShowIf("type", ConversationType.Dialogue)]
        public Dialogue dialogue;
        
        // Option
        [ShowIf("type", ConversationType.Option)]
        public DialogueOption option;
    }
}