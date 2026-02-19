using UnityEngine.EventSystems;
using UnityEngine;
using R3;

namespace Utils
{
    public class PointerDetector : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler
    {
        private bool _isEnabled = true;

        private Subject<PointerEventData> _onPointerClickSignalSubj = new();
        private Subject<PointerEventData> _onPointerEnterSignalSubj = new();
        private Subject<PointerEventData> _onPointerExitSignalSubj = new();
        private Subject<PointerEventData> _onPointerDownSignalSubj = new();
        private Subject<PointerEventData> _onPointerUpSignalSubj = new();

        public Observable<PointerEventData> OnPointerClickSignal => _onPointerClickSignalSubj;
        public Observable<PointerEventData> OnPointerEnterSignal => _onPointerEnterSignalSubj;
        public Observable<PointerEventData> OnPointerExitSignal => _onPointerExitSignalSubj;
        public Observable<PointerEventData> OnPointerDownSignal => _onPointerDownSignalSubj;
        public Observable<PointerEventData> OnPointerUpSignal => _onPointerUpSignalSubj;

        public void Enable() => _isEnabled = true;
        public void Disable() => _isEnabled = false;

        public void OnPointerClick(PointerEventData eventData)
        {
            if (!_isEnabled) return;
            _onPointerClickSignalSubj.OnNext(eventData);
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            if (!_isEnabled) return;
            _onPointerEnterSignalSubj.OnNext(eventData);
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            _onPointerExitSignalSubj.OnNext(eventData);
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            if (!_isEnabled) return;
            _onPointerDownSignalSubj.OnNext(eventData);
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            _onPointerUpSignalSubj.OnNext(eventData);
        }
    }
}
