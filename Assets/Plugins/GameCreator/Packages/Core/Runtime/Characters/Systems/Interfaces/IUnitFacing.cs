﻿using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.Characters
{
    [Title("Rotation")]
    
    public interface IUnitFacing : IUnitCommon
    {
        // PROPERTIES: ----------------------------------------------------------------------------

        Vector3 WorldFaceDirection { get; }
        Vector3 LocalFaceDirection { get; }

        Vector3 WorldTargetFaceDirection { get; }
        Vector3 LocalTargetFaceDirection { get; }

        float PivotSpeed { get; }

        // PUBLIC METHODS: ------------------------------------------------------------------------

        void DeleteLayer(int key);

        int SetLayerDirection(int key, Vector3 direction, bool autoDestroyOnReach);
        int SetLayerTarget(int key, Transform target);
    }
}