using System;
using GameLokal.Toolkit;

namespace JustMonika.VR
{
    public class GamePersistence : BasePersistence, IGameSave
    {
        public GameState gameState;
        public float Affection => gameState.monikaAffection;

        public override string GetUniqueName()
        {
            return name;
        }

        public override object GetSaveData()
        {
            return gameState;
        }

        public override Type GetSaveDataType()
        {
            return typeof(GameState);
        }

        public override void ResetData()
        {
            
        }

        public override void OnLoad(object generic)
        {
            var loaded = (GameState) generic;
            gameState = loaded;
            
        }
        
        public void SendToVariableStorage()
        {
            Blackboard.VariableStorage.SetValue(Constants.VAR_PLAYER_NAME, gameState.playerName);
            Blackboard.VariableStorage.SetValue(Constants.VAR_MONIKA_AFFECTION, gameState.monikaAffection);
        }
    }
}