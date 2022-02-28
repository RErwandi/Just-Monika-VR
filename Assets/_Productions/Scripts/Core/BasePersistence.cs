using System;
using GameLokal.Toolkit;
using UnityEngine;

namespace JustMonika.VR
{
    public class BasePersistence : MonoBehaviour, IGameSave
    {
        public void Initialize()
        {
            SaveLoadManager.Instance.Initialize(this);
        }
        public virtual string GetUniqueName()
        {
            throw new NotImplementedException();
        }

        public virtual object GetSaveData()
        {
            throw new NotImplementedException();
        }

        public virtual Type GetSaveDataType()
        {
            throw new NotImplementedException();
        }

        public virtual void ResetData()
        {
            throw new NotImplementedException();
        }

        public virtual void OnLoad(object generic)
        {
            throw new NotImplementedException();
        }
    }

}