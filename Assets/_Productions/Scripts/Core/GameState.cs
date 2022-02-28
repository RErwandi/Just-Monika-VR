namespace JustMonika.VR
{
    [System.Serializable]
    public class GameState
    {
        public string playerName;
        public int monikaAffection;

        public GameState()
        {
            playerName = "Player";
            monikaAffection = 0;
        }
    }
}