using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SVS.Pickable
{
    public abstract class Pickable : MonoBehaviour
    {
        protected SpriteRenderer spriteRenderer;
        [SerializeField] private BoxCollider2D pickableCollider;

        [SerializeField] protected Color gizmoColor = Color.magenta;

        private void Awake()
        {
            spriteRenderer = GetComponentInChildren<SpriteRenderer>();
            pickableCollider = GetComponent<BoxCollider2D>();
        }

        public abstract void PickUp(Agent agent);

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                PickUp(other.GetComponent<Agent>());
                Destroy(gameObject);
            }
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = gizmoColor;
            Gizmos.DrawCube(pickableCollider.bounds.center, pickableCollider.bounds.size);
        }
    }
}


