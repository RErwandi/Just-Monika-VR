using UnityEngine;
using Yarn.Unity;

namespace JustMonika.VR
{
    public class MonikaYarnCommand : MonoBehaviour
    {
        [YarnCommand("set_face")]
        public static void SetFace(string eyes, string eyebrows, string mouth, string blush)
        {
            Monika.Instance.Facial.SetFacial(eyes, eyebrows, mouth, blush);
        }

        [YarnCommand("set_eyes")]
        public static void SetEyes(string eyes)
        {
            Monika.Instance.Facial.SetEyes(eyes);
        }
        
        [YarnCommand("set_eyebrows")]
        public static void SetEyebrows(string eyebrows)
        {
            Monika.Instance.Facial.SetEyebrows(eyebrows);
        }
        
        [YarnCommand("set_mouth")]
        public static void SetMouth(string mouth)
        {
            Monika.Instance.Facial.SetMouth(mouth);
        }
        
        [YarnCommand("set_blush")]
        public static void SetBlush(string blush)
        {
            Monika.Instance.Facial.SetBlush(blush);
        }
    }
}