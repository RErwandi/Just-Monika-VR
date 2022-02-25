using System;
using Febucci.UI;
using TMPro;
using UnityEngine;

namespace JustMonika.VR
{
    public class MonikaDialogueView : MonoBehaviour
    {
        public TextMeshProUGUI dialogueText;
        public TextAnimatorPlayer textAnimatorPlayer;

        private Action onNext;

        private void Start()
        {
            textAnimatorPlayer.onTextShowed.AddListener(Next);
        }

        private void OnDestroy()
        {
            textAnimatorPlayer.onTextShowed.RemoveListener(Next);
        }
        
        public void RegisterNextButton(Action callback)
        {
            onNext = callback;
        }

        public void Show()
        {
            gameObject.SetActive(true);
        }

        public void Hide()
        {
            gameObject.SetActive(false);
        }

        public void PlayText(string s)
        {
            dialogueText.text = s;
        }

        private void Next()
        {
            onNext?.Invoke();
        }
    } 
}