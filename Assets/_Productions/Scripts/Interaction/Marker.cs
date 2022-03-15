using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JustMonika.VR
{
    public class Marker : MonoBehaviour
    {
        void OnDrawGizmos()
        {
            // Draw a yellow sphere at the transform's position
            Gizmos.color = new Color(1, 0, 0, 0.5f);
            Gizmos.DrawCube(transform.position, new Vector3(0.3f, 0.01f, 0.3f));
        }
    }
}