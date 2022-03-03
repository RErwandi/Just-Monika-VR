namespace JustMonika.VR
{
    [System.Serializable]
    public class GameState
    {
        public string playerName;
        public float monikaAffection;
        public float randomTopicInterval = 15f;

        public GameState()
        {
            playerName = "Player";
            monikaAffection = 0f;
        }
    }
}