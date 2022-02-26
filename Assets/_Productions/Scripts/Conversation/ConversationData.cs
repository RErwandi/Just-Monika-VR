using System.Collections.Generic;
using UnityEngine;

namespace JustMonika.VR
{
    public class ConversationData : ScriptableObject
    {
        public List<ConversationEvent> conversationEvents = new List<ConversationEvent>();
    }
}