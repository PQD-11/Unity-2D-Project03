using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SVS.AI
{
    public class AIEndPlatformDetector : MonoBehaviour
    {
        public BoxCollider2D detectorCollider;
        public LayerMask groundMask;
        public float groundRayCastLength = 2;

        [Range(0, 1)]
        public float groundRayCastDelay = 0.1f;

        public bool PathBlocked { get; private set; }
        public event Action OnPathBlocked;

        [Header("Gizmo Paramaters")]
        public Color colliderColor = Color.magenta;
        public Color groundRayCastColor = Color.blue;
        public bool showGizmos = true;

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.layer == LayerMask.NameToLayer("ClimbingStuff")) { return; }
            OnPathBlocked?.Invoke();
        }

        private void Start()
        {
            StartCoroutine(CheckGroundCoroutine());
        }

        IEnumerator CheckGroundCoroutine()
        {
            yield return new WaitForSecondsRealtime(groundRayCastDelay);
            var hit = Physics2D.Raycast(detectorCollider.bounds.center, Vector2.down, groundRayCastLength, groundMask);
            if (hit.collider == null)
            {
                OnPathBlocked?.Invoke();
            }

            PathBlocked = hit.collider == null;
            StartCoroutine(CheckGroundCoroutine());
        }

        private void OnDrawGizmos()
        {
            if (showGizmos && detectorCollider != null)
            {
                Gizmos.color = groundRayCastColor;
                Gizmos.DrawRay(detectorCollider.bounds.center, Vector2.down * groundRayCastLength);
                Gizmos.color = colliderColor;
                Gizmos.DrawCube(detectorCollider.bounds.center, detectorCollider.bounds.size);
            }
        }
    }
}
