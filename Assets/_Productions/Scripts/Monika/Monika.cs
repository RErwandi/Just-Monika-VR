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
        }

        private void Start()
        {
            if (Camera.main is not null) lookAtIk.solver.target = Camera.main.transform;
        }
    }
}