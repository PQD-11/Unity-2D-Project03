using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SVS.AI
{
    public class AIPlayerEnterAreaDetector : MonoBehaviour
    {
        [field: SerializeField] public bool PlayerInArea { get; private set; }
        public Transform Player { get; private set; }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                PlayerInArea = true;
                Player = other.gameObject.transform;

            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                PlayerInArea = false;
                Player = null;
            }
        }
    }
}

