using System;
using GameLokal.Toolkit;
using RootMotion.FinalIK;
using UnityEngine;

namespace JustMonika.VR
{
    public class Monika : Singleton<Monika>
    {
        protected override bool ShouldNotDestroyOnLoad()
        {
            return false;
        }

        [SerializeField] private Animator animator;
        private Collider coll;
        private Rigidbody rb;

        private MonikaFacial facial;
        public MonikaFacial Facial => facial;

        public MonikaAffection Affection
        {
            get
            {
                var currentAffection = Blackboard.GamePersistence.Affection;
                foreach (var affectionSetting in GameConfig.Instance.affectionSettings)
                {
                    if (currentAffection >= affectionSetting.reqAffection)
                    {
                        return affectionSetting.affection;
                    }
                }

                return MonikaAffection.Normal;
            }
        }

        [SerializeField] private LookAtIK lookAtIk;

        protected override void Awake()
        {
            facial = GetComponent<MonikaFacial>();
            coll = GetComponentInChildren<Collider>();
            rb = GetComponentInChildren<Rigidbody>();
        }

        private void Start()
        {
            if (Camera.main is not null) lookAtIk.solver.target = Camera.main.transform;
        }
        
        public static void Teleport(Marker marker)
        {
            var m = marker.transform;
            Instance.transform.position = m.position;
            Instance.transform.rotation = m.rotation;
        }

        public static void Mount()
        {
            if(Instance.coll != null)
                Instance.coll.enabled = false;
            if(Instance.rb != null)
                Instance.rb.isKinematic = true;
        }
        
        public static void UnMount()
        {
            if(Instance.coll != null)
                Instance.coll.enabled = true;
            if(Instance.rb != null)
                Instance.rb.isKinematic = false;
        }

        public void SetAnim(string param, bool value)
        {
            animator.SetBool(param, value);
        }
        
        public void SetAnim(string param, float value)
        {
            animator.SetFloat(param, value);
        }
    }
}