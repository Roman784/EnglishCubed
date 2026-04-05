using R3;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class AbilitySelectionButton : MonoBehaviour
    {
        [SerializeField] private Image _iconView;
        [SerializeField] private GameObject _lockView;

        private Subject<bool> _selectedSignalSubj = new();
        private bool _isLocked;

        public Observable<bool> SelectedSignal => _selectedSignalSubj;

        public void SetIcon(Sprite icon)
        {
            _iconView.sprite = icon;
        }

        public void SetIsLocked(bool isLocked)
        {
            _isLocked = isLocked;
            _lockView.SetActive(isLocked);
        }

        public void Select()
        {
            _selectedSignalSubj.OnNext(_isLocked);
        }
    }
}