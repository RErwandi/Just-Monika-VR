using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Sirenix.OdinInspector;
using UnityEngine;
using Yarn.Unity;
using Random = UnityEngine.Random;

namespace JustMonika.VR
{
    public class MonikaFacial : MonoBehaviour
    {
        public SkinnedMeshRenderer skinnedMeshRenderer;

        [Title("Facial Database")]
        [AssetList(Path = "_Databases/Facial Emotion/Eyes", AutoPopulate = true)]
        public List<FacialData> availableEyes = new List<FacialData>();
        [AssetList(Path = "_Databases/Facial Emotion/Eyebrows", AutoPopulate = true)]
        public List<FacialData> availableEyebrows = new List<FacialData>();
        [AssetList(Path = "_Databases/Facial Emotion/Mouth", AutoPopulate = true)]
        public List<FacialData> availableMouth = new List<FacialData>();
        [AssetList(Path = "_Databases/Facial Emotion/Blush", AutoPopulate = true)]
        public List<FacialData> availableBlush = new List<FacialData>();

        [Title("Blink Settings")]
        public bool autoBlink = true;
        [ShowIf("autoBlink")]
        public Vector2 autoBlinkInterval = new Vector2(5f, 30f);
        [ShowIf("autoBlink")]
        public FacialData blinkFacialData;
        private float blinkValue;
        private bool isBlinking;

        [Title("Lips Settings")]
        public bool lipSync = true;
        [ShowIf("lipSync")]
        public FacialData talkingFacialData;
        private float talkingValue;
        private bool isTalking;
        
        private Mesh skinnedMesh;
        private bool hasFacial;
        private DialogueRunner dialogueRunner;

        private void Awake()
        {
            skinnedMesh = skinnedMeshRenderer.sharedMesh;
        }

        private void Start()
        {
            if(autoBlink)
                StartCoroutine(Blink());

            dialogueRunner = DialogueSystem.Instance.dialogueRunner;
        }

        private void OnDestroy()
        {
            StopAllCoroutines();
        }

        private void Update()
        {
            if (isBlinking)
            {
                skinnedMeshRenderer.SetBlendShapeWeight(blinkFacialData.settings[0].index, blinkValue);
            }

            if (isTalking)
            {
                skinnedMeshRenderer.SetBlendShapeWeight(talkingFacialData.settings[0].index, talkingValue);
            }
        }

        private IEnumerator Blink()
        {
            var randomInterval = Random.Range(autoBlinkInterval.x, autoBlinkInterval.y);
            yield return new WaitForSeconds(randomInterval);
            
            // We don't want her to blink when she displaying another facial emotion
            if (!hasFacial)
            {
                isBlinking = true;
                DOTween.To(()=> blinkValue, x=> blinkValue = x, blinkFacialData.settings[0].value, 0.1f);
                yield return new WaitForSeconds(0.33f);
                DOTween.To(()=> blinkValue, x=> blinkValue = x, 0f, 0.1f);
                yield return new WaitForSeconds(0.1f);
                isBlinking = false;
            }
            
            StartCoroutine(Blink());
        }

        public void SetFacial(FacialData eyes, FacialData eyebrows, FacialData mouth, FacialData blush)
        {
            ResetFacial();
            
            foreach (var facial in eyes.settings)
            {
                skinnedMeshRenderer.SetBlendShapeWeight(facial.index, facial.value);
            }
            
            foreach (var facial in eyebrows.settings)
            {
                skinnedMeshRenderer.SetBlendShapeWeight(facial.index, facial.value);
            }
            
            foreach (var facial in mouth.settings)
            {
                skinnedMeshRenderer.SetBlendShapeWeight(facial.index, facial.value);
            }
            
            foreach (var facial in blush.settings)
            {
                skinnedMeshRenderer.SetBlendShapeWeight(facial.index, facial.value);
            }

            hasFacial = true;
        }

        public void ResetFacial()
        {
            for (int i = 0; i < skinnedMesh.blendShapeCount; i++)
            {
                skinnedMeshRenderer.SetBlendShapeWeight(i, 0f);
            }

            hasFacial = false;
        }

        public void StartTalking()
        {
            if (isTalking) return;
            
            isTalking = true;
            StartCoroutine(Talking());
        }

        public void StopTalking()
        {
            if (!isTalking) return;
            
            isTalking = false;
            skinnedMeshRenderer.SetBlendShapeWeight(talkingFacialData.settings[0].index, 0f);
        }
        
        private IEnumerator Talking()
        {
            DOTween.To(()=> talkingValue, x=> talkingValue = x, talkingFacialData.settings[0].value, 0.1f);
            yield return new WaitForSeconds(0.1f);
            DOTween.To(()=> talkingValue, x=> talkingValue = x, 0f, 0.1f);
            yield return new WaitForSeconds(0.1f);
            
            StartCoroutine(Talking());
        }
    }
}