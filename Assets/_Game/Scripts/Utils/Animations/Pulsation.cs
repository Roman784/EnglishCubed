using UnityEngine;

namespace Utils
{
    public class Pulsation : MonoBehaviour
    {
        [SerializeField] private float _amplitude;
        [SerializeField] private float _period;

        private void Update()
        {
            transform.localScale = Vector3.one + Vector3.one * Mathf.Sin(Time.time * (1f / _period)) * _amplitude;
        }
    }
}