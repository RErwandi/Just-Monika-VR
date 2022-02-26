using GameLokal.Toolkit;
using Yarn.Unity;

namespace JustMonika.VR
{
    public class DialogueSystem : Singleton<DialogueSystem>
    {
        protected override bool ShouldNotDestroyOnLoad()
        {
            return false;
        }

        public DialogueRunner dialogueRunner;

        private void Start()
        {
            
        }

        public void StartDialogue(string node)
        {
            dialogueRunner.StartDialogue(node);
        }
    }
}