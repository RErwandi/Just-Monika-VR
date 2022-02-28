using GameLokal.Toolkit;
using UnityEngine;

namespace JustMonika.VR
{
    public class Blackboard : Singleton<Blackboard>
    {
        [SerializeField] private GamePersistence gamePersistence;
        public static GamePersistence GamePersistence => Instance.gamePersistence;
        
        private void Start()
        {
            InitializeAllPersistence();
            
            SaveLoadManager.Instance.Load();
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