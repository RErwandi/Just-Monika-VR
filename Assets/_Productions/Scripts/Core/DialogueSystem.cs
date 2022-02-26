using Febucci.UI;
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

        public void StartDialogue(string node)
        {
            dialogueRunner.StartDialogue(node);
        }
    }
}