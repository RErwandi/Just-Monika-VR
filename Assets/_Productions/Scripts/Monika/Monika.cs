using GameLokal.Toolkit;

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

        protected override void Awake()
        {
            facial = GetComponent<MonikaFacial>();
        }
    }
}