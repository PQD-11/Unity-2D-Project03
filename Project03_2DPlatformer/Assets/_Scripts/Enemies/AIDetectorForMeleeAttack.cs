using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace SVS.AI
{
    public class AIDetectorForMeleeAttack : MonoBehaviour
    {
        public bool PlayerDetected { get; private set; }
        public LayerMask targetLayerMask;

        public UnityEvent<GameObject> OnPlayerDetected;

        [Header("Gizmo Paramaters")]
        [Range(0.1f, 1)]
        public float radius;
        public Color gizmoColor = Color.green;
        public bool showGizmos = true;

        private void Update()
        {
            Collider2D collider = Physics2D.OverlapCircle(transform.position, radius, targetLayerMask);
            PlayerDetected = collider != null;
            if (PlayerDetected)
            {
                OnPlayerDetected?.Invoke(collider.gameObject);
            }
        }

        private void OnDrawGizmos()
        {
            if (showGizmos)
            {
                Gizmos.color = gizmoColor;
                Gizmos.DrawSphere(transform.position, radius);
            }
        }

    }
}

