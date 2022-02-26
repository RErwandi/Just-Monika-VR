using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

namespace JustMonika.VR
{
    public class Classroom : MonoBehaviour
    {
        [AssetList(Path = "_Databases/Conversations/Random Topics", AutoPopulate = true)]
        public List<ConversationData> randomTopics = new List<ConversationData>();

        private void Start()
        {
            StartCoroutine(PlayRandomChat());
        }

        private IEnumerator PlayRandomChat()
        {
            yield return new WaitForSeconds(GameSettings.Instance.randomChatInterval);
            var topic = GetRandomTopic();
            Monika.Instance.PlayConversation(topic, delegate { StartCoroutine(PlayRandomChat()); });
        }

        private ConversationData GetRandomTopic()
        {
            var r = Random.Range(0, randomTopics.Count);
            return randomTopics[r];
        }
    }
}