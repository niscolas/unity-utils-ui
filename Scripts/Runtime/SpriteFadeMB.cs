using System.Collections.Generic;
using DG.Tweening;
using UnityAtoms.BaseAtoms;
using UnityEngine;
using UnityEngine.UI;

namespace niscolas.UnityUtils.UI
{
    [AddComponentMenu(Constants.AddComponentMenuPrefix + "Sprite Fade")]
    public class SpriteFadeMB : MonoBehaviour
    {
        [SerializeField]
        private FloatReference _fadeInDuration;

        [SerializeField]
        private Ease _fadeInEase;

        [SerializeField]
        private FloatReference _activatedDuration;

        [SerializeField]
        private FloatReference _fadeOutDuration;

        [SerializeField]
        private Ease _fadeOutEase;

        private IEnumerable<Graphic> _graphics;

        private IEnumerable<SpriteRenderer> _spriteRenderers;

        private void Start()
        {
            _spriteRenderers = GetComponentsInChildren<SpriteRenderer>(true);
            _graphics = GetComponentsInChildren<Graphic>(true);

            gameObject.SetActive(false);
        }

        public Tween FadeIn()
        {
            gameObject.SetActive(true);
            return FadeTo(1, _fadeInDuration, _fadeInEase);
        }

        public Tween FadeOut()
        {
            return FadeTo(0, _fadeOutDuration, _fadeOutEase)
                .OnComplete(() => gameObject.SetActive(false));
        }

        public void FadeInOut()
        {
            Sequence sequence = DOTween.Sequence();
            sequence.Append(FadeIn());
            sequence.AppendInterval(_activatedDuration);
            sequence.Append(FadeOut());
        }

        public Tween FadeTo(float alpha, float duration, Ease ease)
        {
            Sequence sequence = DOTween.Sequence();

            foreach (SpriteRenderer spriteRenderer in _spriteRenderers)
            {
                sequence.Join(
                    spriteRenderer
                        .DOFade(alpha, duration)
                        .SetEase(ease));
            }

            foreach (Graphic graphic in _graphics)
            {
                sequence.Join(
                    graphic
                        .DOFade(alpha, duration)
                        .SetEase(ease));
            }

            return sequence;
        }
    }
}