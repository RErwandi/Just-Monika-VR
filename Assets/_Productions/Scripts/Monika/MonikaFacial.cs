using System;
using System.Collections;
using DG.Tweening;
using Sirenix.OdinInspector;
using UnityEngine;
using Random = UnityEngine.Random;

namespace JustMonika.VR
{
    public class MonikaFacial : MonoBehaviour
    {
        public SkinnedMeshRenderer skinnedMeshRenderer;

        [Title("Blink Settings")]
        public bool autoBlink = true;
        [ShowIf("autoBlink")]
        public Vector2 autoBlinkInterval = new Vector2(5f, 30f);
        [ShowIf("autoBlink")]
        public FacialData blinkFacialData;
        private float blinkValue;
        private bool isBlinking;
        
        private Mesh skinnedMesh;
        private bool hasFacial;

        private void Awake()
        {
            skinnedMesh = skinnedMeshRenderer.sharedMesh;
        }

        private void Start()
        {
            if(autoBlink)
                StartCoroutine(Blink());
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

        [Button]
        public void SetFacial(FacialData facialData)
        {
            ResetFacial();
            
            foreach (var facial in facialData.settings)
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
    }
}