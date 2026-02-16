using UnityEngine.EventSystems;
using UnityEngine;
using R3;

namespace Utils
{
    public class PointerDetector : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
    {
        private bool _isEnabled = true;

        private Subject<PointerEventData> _onPointerClickSignalSubj = new();
        private Subject<PointerEventData> _onPointerEnterSignalSubj = new();
        private Subject<PointerEventData> _onPointerExitSignalSubj = new();

        public bool IsHover { get; private set; }
        public Observable<PointerEventData> OnPointerClickSignal => _onPointerClickSignalSubj;
        public Observable<PointerEventData> OnPointerEnterSignal => _onPointerEnterSignalSubj;
        public Observable<PointerEventData> OnPointerExitSignal => _onPointerExitSignalSubj;

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

            IsHover = true;
            _onPointerEnterSignalSubj.OnNext(eventData);
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            IsHover = false;
            _onPointerExitSignalSubj.OnNext(eventData);
        }
    }
}
