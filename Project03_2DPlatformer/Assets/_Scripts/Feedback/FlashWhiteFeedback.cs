using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SVS.Feedback
{
    public class FlashWhiteFeedback : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer spriteRenderer;
        [SerializeField] private float feedbackTime = 0.1f;

        public void PlayFeedback()
        {
            if (spriteRenderer == null || spriteRenderer.material.HasProperty("_MakeSolidColor") == false)
            {
                return;
            }

            ToggleMeterial(1);
            StopAllCoroutines();
            StartCoroutine(ResetColor());
        }

        private void ToggleMeterial(int v)
        {
            v = Mathf.Clamp(v, 0, 1);
            spriteRenderer.material.SetInt("_MakeSolidColor", v);
        }

        IEnumerator ResetColor()
        {
            yield return new WaitForSecondsRealtime(feedbackTime);
            ToggleMeterial(0);
        }
    }
}

