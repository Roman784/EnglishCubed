using GameRoot;
using UnityEngine;

namespace UI
{
    public class FullscreenUIFactory
    {
        // Creates and attaches a UI to the root.
        public T Create<T>(T prefab) where T : FullscreenUI
        {
            var newUI = Object.Instantiate<T>(prefab);
            G.UIRoot.AttachFullsreenUI(newUI);

            return newUI;
        }
    }
}
