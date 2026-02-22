using UnityEngine;

namespace UI
{
    [RequireComponent(typeof(RectTransform))]
    public class StarrySky : MonoBehaviour
    {
        [SerializeField] private DecorationStar _prefab;
        [SerializeField] private int _initialCount;
        [SerializeField] private float _cooldown;

        private RectTransform _rectTransform;
        private float _nextSpawnTime;

        private void Start()
        {
            _rectTransform = GetComponent<RectTransform>();

            for (int i = 0; i < _initialCount; i++)
            {
                SpawnStar();
            }
        }

        private void Update()
        {
            if (_nextSpawnTime < Time.time)
            {
                _nextSpawnTime = Time.time + _cooldown;
                SpawnStar();
            }
        }

        private void SpawnStar()
        {
            var createdStar = Instantiate(_prefab, _rectTransform, false);
            createdStar.transform.position = GetRandomPosition();
            //createdStar.Show(GetAlpha(createdStar.transform.position.y));
        }

        private Vector2 GetRandomPosition()
        {
            var containerCorners = new Vector3[4];
            _rectTransform.GetWorldCorners(containerCorners);

            var minScreenContainerCorner = RectTransformUtility.WorldToScreenPoint(null, containerCorners[0]);
            var maxScreenContainerCorner = RectTransformUtility.WorldToScreenPoint(null, containerCorners[2]);

            var randomX = Random.Range(minScreenContainerCorner.x, maxScreenContainerCorner.x);
            var randomY = Random.Range(minScreenContainerCorner.y, maxScreenContainerCorner.y);

            return new Vector2(randomX, randomY);
        }

        private float GetAlpha(float y)
        {
            return 1;
            /*var t = _rectTransform.sizeDelta.y 
            return Mathf.Lerp(0, 1, t);*/
        }
    }
}