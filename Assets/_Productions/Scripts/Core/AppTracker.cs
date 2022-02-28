using GameLokal.Toolkit;
using UnityEngine;

namespace JustMonika.VR
{
    public class AppTracker : MonoBehaviour
    {
        private void OnBackground()
        {
            GameEvent.Trigger(Constants.ON_APPLICATION_BACKGROUND);
        }

        private void OnApplicationQuit()
        {
            GameEvent.Trigger(Constants.ON_APPLICATION_QUIT);
        }
    }
}