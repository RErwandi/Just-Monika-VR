using GameLokal.Toolkit;
using Sirenix.OdinInspector;
using UnityEngine;

namespace JustMonika.VR
{
    public class Player : Singleton<Player>
    {
        [SerializeField] private Transform camera;
        
        [Title("Crouch")]
        [SerializeField] private float crouchDivider = 1.5f;
        private FirstPersonLook firstPersonLook;
        private FirstPersonMovement firstPersonMovement;
        private CapsuleCollider coll;
        private Rigidbody rb;

        private float originHeight;
        private float originCenter;
        private float originCameraY;

        protected override void Awake()
        {
            base.Awake();
            firstPersonLook = GetComponentInChildren<FirstPersonLook>();
            firstPersonMovement = GetComponentInChildren<FirstPersonMovement>();
            coll = GetComponentInChildren<CapsuleCollider>();
            rb = GetComponentInChildren<Rigidbody>();
            originCenter = coll.center.y;
            originHeight = coll.height;
            originCameraY = camera.localPosition.y;
        }

        public void DisableMovement()
        {
            firstPersonMovement.enabled = false;
        }
        
        public void EnableMovement()
        {
            firstPersonMovement.enabled = true;
        }

        public void DisableCameraMovement()
        {
            firstPersonLook.enabled = false;
        }
        
        public void EnableCameraMovement()
        {
            firstPersonLook.enabled = true;
        }

        public void Teleport(Marker marker)
        {
            var m = marker.transform;
            transform.position = m.position;
            transform.rotation = m.rotation;
        }

        public void Mount()
        {
            if(coll != null)
                coll.enabled = false;
            if(rb != null)
                rb.isKinematic = true;
        }
        
        public void UnMount()
        {
            if(coll != null)
                coll.enabled = true;
            if(rb != null)
                rb.isKinematic = false;
        }

        public void Crouch()
        {
            if (coll == null) return;

            coll.height = originHeight / crouchDivider;
            coll.center = new Vector3(0f, originCenter / crouchDivider, 0f);
            camera.localPosition = new Vector3(0f, originCameraY / crouchDivider, 0f);
        }

        public void UnCrouch()
        {
            if (coll == null) return;

            coll.height = originHeight;
            coll.center = new Vector3(0f, originCenter, 0f);
            camera.localPosition = new Vector3(0f, originCameraY, 0f);
        }

        public void FaceFrontCamera()
        {
            camera.localRotation = Quaternion.identity;
        }
    }
}