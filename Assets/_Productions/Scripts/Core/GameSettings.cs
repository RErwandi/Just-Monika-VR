using GameLokal.Toolkit;
using UnityEngine;

namespace JustMonika.VR
{
    public class GameSettings : Singleton<GameSettings>
    {
        public string playerName = "Player";

        [Range(0f, 5f)]
        public float autoForwardTime = 1f;

        public float randomChatInterval = 15f;
    }
}