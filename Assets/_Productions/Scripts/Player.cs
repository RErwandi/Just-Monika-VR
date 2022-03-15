using GameLokal.Toolkit;
using UnityEngine;

namespace JustMonika.VR
{
    public class Player : Singleton<Player>
    {
        private FirstPersonLook firstPersonLook;
        private FirstPersonMovement firstPersonMovement;
        private Collider coll;
        private Rigidbody rb;

        protected override void Awake()
        {
            base.Awake();
            firstPersonLook = GetComponentInChildren<FirstPersonLook>();
            firstPersonMovement = GetComponentInChildren<FirstPersonMovement>();
            coll = GetComponentInChildren<Collider>();
            rb = GetComponentInChildren<Rigidbody>();
        }

        public static void DisableMovement()
        {
            Instance.firstPersonMovement.enabled = false;
        }
        
        public static void EnableMovement()
        {
            Instance.firstPersonMovement.enabled = true;
        }

        public static void DisableCameraMovement()
        {
            Instance.firstPersonLook.enabled = false;
        }
        
        public static void EnableCameraMovement()
        {
            Instance.firstPersonLook.enabled = true;
        }

        public static void Teleport(Marker marker)
        {
            var m = marker.transform;
            Instance.transform.position = m.position;
            Instance.transform.rotation = m.rotation;
        }

        public static void Mount()
        {
            Instance.coll.enabled = false;
            Instance.rb.isKinematic = true;
        }
        
        public static void UnMount()
        {
            Instance.coll.enabled = true;
            Instance.rb.isKinematic = false;
        }
    }
}