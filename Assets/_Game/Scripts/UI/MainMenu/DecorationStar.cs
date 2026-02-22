using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class DecorationStar : MonoBehaviour
    {
        [SerializeField] private CanvasGroup _view;

        private void Update()
        {
            var t = (Time.time + transform.position.x) / 8f;
            _view.alpha = Mathf.PingPong(t, 0.5f) + 0.5f;
            _view.transform.localScale = Vector3.one * (Mathf.PingPong(t, 0.3f) + 0.7f);
        }

        /*public void Show(float alpha)
        {
            var color = _view.color;
            color.a = 0;
            _view.color = color;

            var seq = DOTween.Sequence();
            seq.Append(_view.DOFade(alpha, 1f));
            seq.AppendInterval(2);
            seq.Append(_view.DOFade(0, 1));
            seq.OnComplete(() => Destroy(gameObject));
        }*/
    }
}