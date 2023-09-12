using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClimbingDetector : MonoBehaviour
{
    public LayerMask climbingLayerMask;

    [SerializeField] private bool canClimb;

    [SerializeField]
    public bool CanClimb
    {
        get { return canClimb; }
        private set { canClimb = value; }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        LayerMask layerMask = 1 << other.gameObject.layer;

        if ((climbingLayerMask & layerMask) != 0)
        {
            canClimb = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        LayerMask layerMask = 1 << other.gameObject.layer;

        if ((climbingLayerMask & layerMask) != 0)
        {
            canClimb = false;
        }
    }
}
