using System;
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
        private Action onDialogueComplete;

        private void Start()
        {
            dialogueRunner.onDialogueComplete.AddListener(OnDialogueComplete);
        }

        private void OnDestroy()
        {
            dialogueRunner.onDialogueComplete.RemoveListener(OnDialogueComplete);
        }

        public void StartDialogue(string node, Action onFinish = null)
        {
            onDialogueComplete = onFinish;
            dialogueRunner.StartDialogue(node);
        }

        private void OnDialogueComplete()
        {
            ResetFacial();
            onDialogueComplete?.Invoke();
        }

        private void ResetFacial()
        {
            Monika.Instance.Facial.ResetFacial();
        }
    }
}