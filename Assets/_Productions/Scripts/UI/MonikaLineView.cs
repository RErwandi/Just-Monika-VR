using System;
using System.Collections;
using Febucci.UI;
using TMPro;
using UnityEngine;
using Yarn.Unity;

namespace JustMonika.VR
{
    public class MonikaLineView : DialogueViewBase
    {
        public CanvasGroup canvasGroup;
        public TextAnimatorPlayer textAnimatorPlayer;
        public TextMeshProUGUI lineText = null;
        public float holdTime = 1f;

        private Action onLineFinished;

        private void Start()
        {
            textAnimatorPlayer.onTextShowed.AddListener(AdvanceLine);
            
            HideCanvas();
        }

        private void OnDestroy()
        {
            textAnimatorPlayer.onTextShowed.RemoveListener(AdvanceLine);
        }

        public override void RunLine(LocalizedLine dialogueLine, Action onDialogueLineFinished)
        {
            ShowCanvas();
            lineText.text = dialogueLine.TextWithoutCharacterName.Text;
            onLineFinished = onDialogueLineFinished;
            Monika.Instance.StartTalking();
        }
        
        public override void DismissLine(Action onDismissalComplete)
        {
            HideCanvas();
            onDismissalComplete();
        }

        private void ShowCanvas()
        {
            canvasGroup.alpha = 1;
            canvasGroup.blocksRaycasts = true;
        }

        private void HideCanvas()
        {
            canvasGroup.alpha = 0;
            canvasGroup.blocksRaycasts = false;
        }

        private void AdvanceLine()
        {
            StartCoroutine(HoldAdvance());
        }

        private IEnumerator HoldAdvance()
        {
            Monika.Instance.StopTalking();
            yield return new WaitForSeconds(holdTime);
            onLineFinished?.Invoke();
        }
    }
}