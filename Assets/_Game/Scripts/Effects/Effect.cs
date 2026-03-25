using System.Collections;
using UnityEngine;
using Utils;

namespace Effects
{
    public class Effect : MonoBehaviour
    {
        [SerializeField] private ParticleSystem _particleSystem;

        private Coroutine _destroyRoutine;

        public void Play(bool destroyAfterPlaying = true)
        {
            _particleSystem.Play();

            if (destroyAfterPlaying)
                _destroyRoutine = Coroutines.Start(DestroyAfterPlaying());
        }

        public void Stop()
        {
            Coroutines.Stop(_destroyRoutine);
            _particleSystem.Stop();
        }

        public void Destroy()
        {
            Destroy(gameObject);
        }

        private IEnumerator DestroyAfterPlaying()
        {
            yield return new WaitWhile(() => _particleSystem?.isPlaying ?? true);
            Destroy();
        }

        private void OnDestroy()
        {
            Coroutines.Stop(_destroyRoutine);
        }
    }
}
