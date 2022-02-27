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
            Invoke("StartInitialDialogue", 30f);
        }

        private void StartInitialDialogue()
        {
            DialogueSystem.Instance.StartDialogue("Greeting_Goodday");
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