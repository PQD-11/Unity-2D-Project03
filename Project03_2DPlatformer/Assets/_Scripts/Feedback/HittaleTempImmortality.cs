using System;
using System.Collections;
using System.Collections.Generic;
using System.Security;
using DG.Tweening.Core.Easing;
using UnityEngine;
using WeaponSystem;

namespace SVS.Feedback
{
    public class HittaleTempImmortality : MonoBehaviour, IHittable
    {
        public Collider2D[] collider2Ds = new Collider2D[0];
        public float immortalityTime = 1;

        public SpriteRenderer spriteRenderer;
        public float flashDelay = 0.1f;
        [Range(0, 1)]
        public float flashAlpha = 0.5f;

        [Header("For Debugs ")]
        public bool isImmortal = false;

        private void Awake()
        {
            if (collider2Ds.Length == 0)
            {
                collider2Ds = GetComponents<Collider2D>();
            }
        }

        public void GetHit(GameObject gameObject, int weaponDamage)
        {
            if (!this.enabled) { return; }
            ToggleColliders(false);
            StartCoroutine(ResetColliders());
            StartCoroutine(Flash(flashAlpha));
        }

        private void ToggleColliders(bool v)
        {
            isImmortal = !v;
            foreach (var collider in collider2Ds)
            {
                collider.enabled = v;
            }
        }

        IEnumerator ResetColliders()
        {
            yield return new WaitForSecondsRealtime(immortalityTime);
            StopAllCoroutines();
            ToggleColliders(true);
            ChangeSpriteRendererColorAlpha(1);

        }

        private void ChangeSpriteRendererColorAlpha(float alpha)
        {
            Color color = spriteRenderer.color;
            color.a = alpha;
        }

        IEnumerator Flash(float alpha)
        {
            alpha = Mathf.Clamp01(alpha);
            ChangeSpriteRendererColorAlpha(alpha);
            yield return new WaitForSecondsRealtime(flashDelay);
            StartCoroutine(Flash(alpha < 1 ? 1 : flashAlpha));
        }
    }
}

