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

        protected override void Awake()
        {
            facial = GetComponent<MonikaFacial>();
        }
    }
}