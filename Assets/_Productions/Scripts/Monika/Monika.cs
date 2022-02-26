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

        protected override void Awake()
        {
            facial = GetComponent<MonikaFacial>();
        }

        private void Start()
        {
            DialogueSystem.Instance.StartDialogue("Same_Room");
        }

        public void StartTalking()
        {
            facial.StartTalking();
        }

        public void StopTalking()
        {
            facial.StopTalking();
        }
    }
}