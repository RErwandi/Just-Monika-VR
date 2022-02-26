using GameLokal.Toolkit;

namespace JustMonika.VR
{
    public class Monika : Singleton<Monika>
    {
        protected override bool ShouldNotDestroyOnLoad()
        {
            return false;
        }

        private void Start()
        {
            DialogueSystem.Instance.StartDialogue("Same_Room");
        }
    }
}