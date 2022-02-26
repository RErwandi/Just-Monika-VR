using System;
using System.Collections;
using UnityEngine;

namespace JustMonika.VR
{
    public class MonikaConversation : MonoBehaviour
    {
        public MonikaFacial facial;

        private MonikaDialogueView dialogueView;
        private ConversationData currentConversation;
        private int iDialogue;

        private Action onConversationFinish;
        
        private void Start()
        {
            dialogueView = FindObjectOfType<MonikaDialogueView>();
            dialogueView.RegisterNextButton(NextConversation);
            dialogueView.Hide();
        }

        public void PlayConversation(ConversationData conversation, Action onFinish)
        {
            currentConversation = conversation;
            iDialogue = 0;
            onConversationFinish = onFinish;
            dialogueView.Show();
            
            PlayCurrentConversation();
        }
        
        private void FinishConversation()
        {
            dialogueView.Hide();
            facial.ResetFacial();
            onConversationFinish?.Invoke();
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
            StartCoroutine(DelayConversation());
        }

        private IEnumerator DelayConversation()
        {
            yield return new WaitForSeconds(GameSettings.Instance.autoForwardTime);
            PlayCurrentConversation();
        }
    }
}