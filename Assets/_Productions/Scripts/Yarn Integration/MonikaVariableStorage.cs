using System;
using System.Collections.Generic;
using GameLokal.Toolkit;
using Sirenix.OdinInspector;
using Yarn.Unity;

namespace JustMonika.VR
{
    public class MonikaVariableStorage : VariableStorageBehaviour, IGameSave
    {
        /// <summary>
        /// Where we're actually keeping our variables
        /// </summary>
        [ShowInInspector]
        private Dictionary<string, object> variables = new Dictionary<string, object>();

        public void Initialize()
        {
            SaveLoadManager.Instance.Initialize(this);
        }

        public override void SetValue(string variableName, string stringValue)
        {
            ValidateVariableName(variableName);
            
            variables.TryAddKeyValuePair(variableName, stringValue);
        }

        public override void SetValue(string variableName, float floatValue)
        {
            ValidateVariableName(variableName);
            
            variables.TryAddKeyValuePair(variableName, floatValue);
        }
        
        public override void SetValue(string variableName, bool boolValue)
        {
            ValidateVariableName(variableName);
            
            variables.TryAddKeyValuePair(variableName, boolValue);
        }

        public override void Clear()
        {
            variables.Clear();
        }

        public override bool Contains(string variableName)
        {
            return variables.ContainsKey(variableName);
        }

        public override bool TryGetValue<T>(string variableName, out T result)
        {
            ValidateVariableName(variableName);

            // If we don't have a variable with this name, return the null
            // value
            if (variables.ContainsKey(variableName) == false)
            {
                result = default;
                return false;
            }

            var resultObject = variables[variableName];

            if (typeof(T).IsAssignableFrom(resultObject.GetType()))
            {
                result = (T)resultObject;
                return true;
            }
            else
            {
                throw new System.InvalidCastException($"Variable {variableName} exists, but is the wrong type (expected {typeof(T)}, got {resultObject.GetType()}");
            }
        }
        
        private void ValidateVariableName(string variableName) {
            if (variableName.StartsWith("$") == false) {
                throw new System.ArgumentException($"{variableName} is not a valid variable name: Variable names must start with a '$'. (Did you mean to use '${variableName}'?)");
            }
        }

        public string GetUniqueName()
        {
            return name;
        }

        public object GetSaveData()
        {
            return variables;
        }

        public Type GetSaveDataType()
        {
            return typeof(Dictionary<string, object>);
        }

        public void ResetData()
        {
            
        }

        public void OnLoad(object generic)
        {
            var loaded = (Dictionary<string, object>) generic;
            variables = loaded;
        }
    }
}