using System;
using UnityEngine;
using UnityEngine.Events;

namespace JustMonika.VR
{
    public class Hotspot : MonoBehaviour
    {
        public float radius = 1f;
        public UnityEvent onTriggered;


        private Transform player;
        private bool isAccessible;

        private void Start()
        {
            player = Player.Instance.transform;
        }

        private void Update()
        {
            isAccessible = Vector3.Distance(transform.position, player.position) <= radius;

            if (Input.GetKeyDown(KeyCode.E))
            {
                if (isAccessible)
                {
                    Trigger();
                }
            }
        }

        private void Trigger()
        {
            onTriggered?.Invoke();
        }

        void OnDrawGizmosSelected()
        {
            // Draw a yellow sphere at the transform's position
            Gizmos.color = new Color(1, 0, 0, 0.5f);
            Gizmos.DrawSphere(transform.position, radius);
        }
    }
}