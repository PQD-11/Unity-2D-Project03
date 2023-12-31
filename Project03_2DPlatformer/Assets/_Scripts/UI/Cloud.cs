using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using UnityEngine;

namespace SVS.UI
{
    public class Cloud : MonoBehaviour
    {
        [SerializeField] private float minScale = 3f, maxScale = 5f;
        public float speed = 70;
        public event Action OnOutsideScreen;
        public float outsideScreenDistance;

        private void Update()
        {
            transform.position += Vector3.right * Time.deltaTime *speed;
            if (Vector2.Distance(transform.parent.position, transform.position) > outsideScreenDistance)
            {
                OnOutsideScreen?.Invoke();
                Destroy(gameObject);
            }
        }

        public float GetCloudScale()
        {
            return UnityEngine.Random.Range(minScale, maxScale);
        }

        public void Initialize(float distance, Action onOutsideScreenHandler)
        {
            outsideScreenDistance = distance;
            OnOutsideScreen += onOutsideScreenHandler;
        }
    }
}

