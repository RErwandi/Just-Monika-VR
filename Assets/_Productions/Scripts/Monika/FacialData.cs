using System.Collections.Generic;
using UnityEngine;

namespace JustMonika.VR
{
    public class FacialData : ScriptableObject
    {
        public List<BlendShapeSetting> settings = new List<BlendShapeSetting>();

        [System.Serializable]
        public class BlendShapeSetting
        {
            public int index;
            [Range(0, 100f)]
            public float value;
        }
    }
}