using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
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

        private FacialData lastEyes;
        private FacialData lastEyebrows;
        private FacialData lastMouth;
        private FacialData lastBlush;

        private void Awake()
        {
            skinnedMesh = skinnedMeshRenderer.sharedMesh;
        }

        private void Start()
        {
            if(autoBlink)
                StartCoroutine(Blink());

            dialogueRunner = Blackboard.DialogueSystem.dialogueRunner;
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

        public void SetFacial(string eyes, string eyebrows, string mouth, string blush)
        {
            ResetFacial();

            SetEyes(eyes);
            SetEyebrows(eyebrows);
            SetMouth(mouth);
            SetBlush(blush);
            
            hasFacial = true;
        }

        public void SetEyes(string eyes)
        {
            ResetFacialBlendShape(lastEyes);
            
            var eyesData = GetEyes(eyes);
            lastEyes = eyesData;
            SetFacialBlendShape(eyesData);
        }
        
        public void SetEyebrows(string eyebrows)
        {
            ResetFacialBlendShape(lastEyebrows);
            
            var eyebrowsData = GetEyebrows(eyebrows);
            lastEyebrows = eyebrowsData;
            SetFacialBlendShape(eyebrowsData);
        }

        public void SetMouth(string mouth)
        {
            ResetFacialBlendShape(lastMouth);
            
            var mouthData = GetMouth(mouth);
            lastMouth = mouthData;
            SetFacialBlendShape(mouthData);
        }

        public void SetBlush(string blush)
        {
            ResetFacialBlendShape(lastBlush);
            
            var blushData = GetBlush(blush);
            lastBlush = blushData;
            SetFacialBlendShape(blushData);
        }

        private void SetFacialBlendShape(FacialData data)
        {
            if (data == null) return;
            
            foreach (var facial in data.settings)
            {
                skinnedMeshRenderer.SetBlendShapeWeight(facial.index, facial.value);
            }

            hasFacial = true;
        }

        private void ResetFacialBlendShape(FacialData data)
        {
            if (data == null) return;
            
            foreach (var facial in data.settings)
            {
                skinnedMeshRenderer.SetBlendShapeWeight(facial.index, 0f);
            }
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
            DOTween.To(()=> talkingValue, x=> talkingValue = x, talkingFacialData.settings[0].value, 0.3f);
            yield return new WaitForSeconds(0.3f);
            DOTween.To(()=> talkingValue, x=> talkingValue = x, 0f, 0.1f);
            yield return new WaitForSeconds(0.3f);
            
            StartCoroutine(Talking());
        }

        private FacialData GetEyes(string eyes)
        {
            return availableEyes.FirstOrDefault(available => available.name == eyes);
        }
        
        private FacialData GetEyebrows(string eyebrows)
        {
            return availableEyebrows.FirstOrDefault(available => available.name == eyebrows);
        }
        
        private FacialData GetMouth(string mouth)
        {
            return availableMouth.FirstOrDefault(available => available.name == mouth);
        }
        
        private FacialData GetBlush(string blush)
        {
            return availableBlush.FirstOrDefault(available => available.name == blush);
        }
    }
}