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
            dialogueRunner.onDialogueComplete.AddListener(ResetFacial);
        }

        public void StartDialogue(string node)
        {
            dialogueRunner.StartDialogue(node);
        }

        private void ResetFacial()
        {
            Monika.Instance.Facial.ResetFacial();
        }
    }
}