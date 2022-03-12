using GameLokal.Toolkit;
using UnityEngine;

namespace JustMonika.VR
{
    public class Blackboard : Singleton<Blackboard>
    {
        [SerializeField] private GamePersistence gamePersistence;
        public static GamePersistence GamePersistence => Instance.gamePersistence;

        [SerializeField] private MonikaVariableStorage variableStorage;
        public static MonikaVariableStorage VariableStorage => Instance.variableStorage;

        [SerializeField] private TimeManager timeManager;
        public static TimeManager Time => Instance.timeManager;

        [SerializeField] private DialogueSystem dialogueSystem;
        public static DialogueSystem DialogueSystem => Instance.dialogueSystem;
        
        private void Start()
        {
            InitializeAllPersistence();
            variableStorage.Initialize();
            dialogueSystem.Initialize();
            
            SaveLoadManager.Instance.Load();
            gamePersistence.SendToVariableStorage();
        }
        
        private void InitializeAllPersistence()
        {
            var persitences = GetComponentsInChildren<BasePersistence>();
            foreach (var persistence in persitences)
            {
                persistence.Initialize();
            }
        }
    }
}