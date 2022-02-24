using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace JustMonika.VR
{
    public class MonikaDialogueView : MonoBehaviour
    {
        public TextMeshProUGUI dialogueText;
        public Button nextButton;

        private Action onNext;

        private void OnEnable()
        {
            nextButton.onClick.AddListener(Next);
        }
        
        private void OnDisable()
        {
            nextButton.onClick.RemoveListener(Next);
        }

        private void Start()
        {
            Hide();
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