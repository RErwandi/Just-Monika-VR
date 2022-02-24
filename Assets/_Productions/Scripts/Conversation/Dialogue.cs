using UnityEngine;

namespace JustMonika.VR
{
    [System.Serializable]
    public class Dialogue
    {
        public FacialData face;
        [TextArea]
        public string text;
    }
}