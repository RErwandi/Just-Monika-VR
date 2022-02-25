using System;
using TMPro;
using UnityEngine;

namespace JustMonika.VR
{
    public class MonikaDialogueView : MonoBehaviour
    {
        public TextMeshProUGUI dialogueText;

        private Action onNext;

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
            Invoke("Next", 3f);
        }

        private void Next()
        {
            onNext?.Invoke();
        }
    } 
}