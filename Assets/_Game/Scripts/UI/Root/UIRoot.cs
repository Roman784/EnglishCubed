using R3;
using System.Collections;
using UnityEngine;
using Utils;

namespace UI
{
    public class UIRoot : MonoBehaviour
    {
        [Space]

        [SerializeField] private Transform _fullscreenUIContainer;
        [SerializeField] private MessageMan _messageMan;
        [SerializeField] private PopUpsRoot _popUpsRoot;
        [SerializeField] private LoadingScreen _loadingScreen;

        public PopUpsRoot PopUpsRoot => _popUpsRoot;

        public IEnumerator ShowLoadingScreen()
        {
            yield return _loadingScreen.Show().ToCoroutine();
        }

        public IEnumerator HideLoadingScreen()
        {
            yield return _loadingScreen.Hide().ToCoroutine();
        }

        public void ShowMessage(string message)
        {
            _messageMan.Show(message);
        }

        public void AttachFullsreenUI(FullscreenUI ui)
        {
            ui.transform.SetParent(_fullscreenUIContainer, false);
        }

        public void ClearAllContainers()
        {
            ClearContainer(_fullscreenUIContainer);
            _popUpsRoot.ClearContainer();
        }

        private void ClearContainer(Transform container)
        {
            var childCount = container.childCount;
            for (int i = 0; i < childCount; i++)
            {
                Destroy(container.GetChild(i).gameObject);
            }
        }
    }
}