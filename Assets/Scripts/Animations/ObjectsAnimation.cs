using System;
using UnityEngine;

namespace Animations
{
    public class ObjectsAnimation : MonoBehaviour
    {
        [SerializeField] private float duration = 4.5f;
        private void OnEnable()
        {
            transform.localScale = Vector3.zero;
            LeanTween.scale(gameObject, Vector3.one, 0.3f).setEaseSpring().setOnComplete(() =>
            {
                LeanTween.scale(gameObject, Vector3.zero, duration).setDelay(0.2f);
            });
        }

        private void OnDestroy()
        {
            LeanTween.cancel(gameObject);
        }
    }
}