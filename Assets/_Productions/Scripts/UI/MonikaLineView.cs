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
        public TextAnimatorPlayer textAnimatorPlayer;
        public TextMeshProUGUI lineText = null;
        public float holdTime = 1f;

        private Action onLineFinished;

        private void Start()
        {
            textAnimatorPlayer.onTextShowed.AddListener(AdvanceLine);
        }

        private void OnDestroy()
        {
            textAnimatorPlayer.onTextShowed.RemoveListener(AdvanceLine);
        }

        public override void RunLine(LocalizedLine dialogueLine, Action onDialogueLineFinished)
        {
            lineText.text = dialogueLine.TextWithoutCharacterName.Text;
            onLineFinished = onDialogueLineFinished;
        }

        private void AdvanceLine()
        {
            StartCoroutine(HoldAdvance());
        }

        private IEnumerator HoldAdvance()
        {
            yield return new WaitForSeconds(holdTime);
            onLineFinished?.Invoke();
        }
    }
}