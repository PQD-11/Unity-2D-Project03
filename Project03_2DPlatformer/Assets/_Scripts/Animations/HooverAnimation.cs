using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Rendering;

namespace SVS.Animation
{
    public class HooverAnimation : MonoBehaviour
    {
        public float movementDistance = 0.5f;
        public float animationDuration = 1;
        public Ease animationEase;

        private void Start()
        {
            transform
                .DOMoveY(transform.position.y + movementDistance, animationDuration)
                .SetEase(animationEase)
                .SetLoops(-1, LoopType.Yoyo);
        }

        private void OnDisable()
        {
            DOTween.Kill(transform);
        }
    }
}

