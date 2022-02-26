using System;
using GameLokal.Toolkit;

namespace JustMonika.VR
{
    public class Monika : Singleton<Monika>
    {
        protected override bool ShouldNotDestroyOnLoad()
        {
            return false;
        }

        public MonikaConversation conversation;

        public void PlayConversation(ConversationData data, Action onFinish)
        {
            conversation.PlayConversation(data, onFinish);
        }
    }
}