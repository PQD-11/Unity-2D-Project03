using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

namespace SVS.Camera
{
    public class FollowCameraUtils : MonoBehaviour
    {
        public PolygonCollider2D cameraConfiner;
        public CinemachineConfiner cm_confiner;
        
        public void SetConfiner()
        {
            cm_confiner.m_BoundingShape2D = cameraConfiner;
        }
    } 
}

