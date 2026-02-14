using TestRoom;
using UI;

namespace GameRoot
{
    public class SceneProvider
    {
        private readonly SceneLoader _sceneLoader;

        private SceneEnterParams _currentSceneParams;
        private SceneEnterParams _previousSceneParams;

        public string CurrentSceneName => _currentSceneParams?.SceneName ?? "";

        public SceneProvider(UIRoot uiRoot)
        {
            _sceneLoader = new SceneLoader(uiRoot);
        }

        public void OpenTestRoom()
        {
            var enterParams = new TestRoomEnterParams();
            OpenTestRoom(enterParams);
        }

        private void OpenTestRoom(TestRoomEnterParams enterParams)
        {
            _previousSceneParams = _currentSceneParams;
            _currentSceneParams = enterParams;

            _sceneLoader.LoadAndRunScene
                <TestRoomEntryPoint, TestRoomEnterParams>(enterParams);
        }
    }
}