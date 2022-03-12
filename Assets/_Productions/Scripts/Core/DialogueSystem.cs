using System;
using GameLokal.Toolkit;
using UnityEngine;
using Yarn.Unity;

namespace JustMonika.VR
{
    public class DialogueSystem : MonoBehaviour
    {

        public DialogueRunner dialogueRunner;
        private Action onDialogueComplete;

        public void Initialize()
        {
            dialogueRunner.VariableStorage = Blackboard.VariableStorage;
        }

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