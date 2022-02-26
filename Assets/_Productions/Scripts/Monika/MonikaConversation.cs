using System;
using System.Collections;
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

        private Action onConversationFinish;
        
        private void Start()
        {
            dialogueView = FindObjectOfType<MonikaDialogueView>();
            dialogueView.RegisterNextButton(NextConversation);
            dialogueView.Hide();
        }

        [Button]
        public void PlayConversation(ConversationData conversation, Action onFinish = null)
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
            if (iDialogue >= currentConversation.conversationEvents.Count)
            {
                FinishConversation();
                return;
            }
            
            if (currentConversation.conversationEvents[iDialogue].dialogue != null)
            {
                PlayDialogue(currentConversation.conversationEvents[iDialogue].dialogue);
                facial.StartTalking();
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
            facial.StopTalking();
            yield return new WaitForSeconds(GameSettings.Instance.autoForwardTime);
            PlayCurrentConversation();
        }
    }
}