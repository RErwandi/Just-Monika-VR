using System.Collections.Generic;

namespace JustMonika.VR
{
    [System.Serializable]
    public class GameState
    {
        public string playerName;
        public float monikaAffection;
        public float randomTopicInterval = 15f;
        public bool repeatTopics;

        public List<string> visitedTopics = new List<string>();

        public GameState()
        {
            playerName = "Player";
            monikaAffection = 0f;
        }
    }
}