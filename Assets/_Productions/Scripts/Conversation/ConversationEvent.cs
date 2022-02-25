using GameLokal.Toolkit;

namespace JustMonika.VR
{
    public struct ConversationEvent
    {
        public ConversationData Data;

        public ConversationEvent(ConversationData newData)
        {
            Data = newData;
        }

        private static ConversationEvent _event;

        public static void Trigger(ConversationData newData)
        {
            _event.Data = newData;
            EventManager.TriggerEvent(_event);
        }
    }
}