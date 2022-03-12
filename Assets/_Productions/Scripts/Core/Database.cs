using System.Collections.Generic;
using GameLokal.Toolkit;
using Sirenix.OdinInspector;
using UnityEngine;

namespace JustMonika.VR
{
    public class Database : Singleton<Database>
    {
        protected override bool ShouldNotDestroyOnLoad()
        {
            return false;
        }

        [AssetList(Path = "/_Databases/Dialogues/Greetings", AutoPopulate = true)]
        public List<GreetingSetting> greetings = new List<GreetingSetting>();
        public static List<GreetingSetting> Greetings => Instance.greetings;
        
        [AssetList(Path = "/_Databases/Dialogues/Topics", AutoPopulate = true)]
        public List<DialogueSetting> topics = new List<DialogueSetting>();
        public static List<DialogueSetting> Topics => Instance.topics;
        
        public static DialogueSetting GetTopic(int index)
        {
            return Instance.topics[index];
        }
        
        public static GreetingSetting GetGreeting(int index)
        {
            return Instance.greetings[index];
        }
        
        public static GreetingSetting GetRandomGreeting()
        {
            GreetingSetting chosenGreeting;
            do
            {
                var r = Random.Range(0, Greetings.Count);
                chosenGreeting = Greetings[r];
            } while (!chosenGreeting.HasValidCondition());
            
            return chosenGreeting;
        }
    }
}