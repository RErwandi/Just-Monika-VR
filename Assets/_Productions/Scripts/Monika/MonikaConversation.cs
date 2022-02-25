using System;
using Sirenix.OdinInspector;
using UnityEngine;

namespace JustMonika.VR
{
    public class MonikaConversation : MonoBehaviour
    {
        public MonikaFacial facial;

        private MonikaDialogueView dialogueView;
        private ConversationData currentConversation;
        private int iDialogue;

        private void Start()
        {
            dialogueView = FindObjectOfType<MonikaDialogueView>();
            dialogueView.RegisterNextButton(NextConversation);
            dialogueView.Hide();
        }

        [Button]
        public void PlayConversation(ConversationData conversation)
        {
            currentConversation = conversation;
            iDialogue = 0;
            dialogueView.Show();
            
            PlayCurrentConversation();
        }
        
        private void FinishConversation()
        {
            dialogueView.Hide();
            facial.ResetFacial();
        }

        private void PlayCurrentConversation()
        {
            if (iDialogue >= currentConversation.dialogues.Count)
            {
                FinishConversation();
                return;
            }
            
            if (currentConversation.dialogues[iDialogue] != null)
            {
                PlayDialogue(currentConversation.dialogues[iDialogue]);
            }
        }

        private void PlayDialogue(Dialogue dialogue)
        {
            if(dialogue.face != null)
                facial.SetFacial(dialogue.face);

            dialogueView.PlayText(dialogue.text);
        }
        
        private void NextConversation()
        {
            iDialogue++;
            PlayCurrentConversation();
        }
    }
}