using System.Collections;
using System.Collections.Generic;
using RespawnSystem;
using UnityEngine;

public class DestroyFallingObject : MonoBehaviour
{
    public LayerMask destroyLayerMask;
    public Vector2 size;

    [Header("Gizmo  Parameters")]
    public Color gizmoColor = Color.red;
    public bool showGizmo = true;

    private void FixedUpdate()
    {
        Collider2D collider2D = Physics2D.OverlapBox(transform.position, size, 0, destroyLayerMask);
        if (collider2D != null)
        {
            Agent agent = collider2D.GetComponent<Agent>();
            if (agent == null)
            {
                Destroy(collider2D.gameObject);
                return;
            }
            var damageable = agent.GetComponent<Damageable>();
            if (damageable != null)
            {
                damageable.GetHit(1);
                if (damageable.CurrentHealth == 0 && agent.CompareTag("Player"))
                {
                    agent.GetComponent<RespawnHelper>().RespawnPlayer();
                }
            }
            agent.AgentDied();
        }
    }

    private void OnDrawGizmos() {
        if (showGizmo)
        {
            Gizmos.color = gizmoColor;
            Gizmos.DrawCube(transform.position, size);
        }
    }
}
