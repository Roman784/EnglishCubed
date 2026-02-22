using MainMenu;
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

        public void OpenMainMenu()
        {
            var enterParams = new MainMenuEnterParams();
            OpenMainMenu(enterParams);
        }

        public void OpenTestRoom()
        {
            var enterParams = new TestRoomEnterParams();
            OpenTestRoom(enterParams);
        }

        private void OpenMainMenu(MainMenuEnterParams enterParams)
        {
            OpenScene<MainMenuEntryPoint, MainMenuEnterParams>(enterParams);
        }

        private void OpenTestRoom(TestRoomEnterParams enterParams)
        {
            OpenScene<TestRoomEntryPoint, TestRoomEnterParams>(enterParams);
        }

        private void OpenScene<TEntryPoint, TEnterParams>(TEnterParams enterParams) 
            where TEntryPoint : SceneEntryPoint 
            where TEnterParams : SceneEnterParams
        {
            _previousSceneParams = _currentSceneParams;
            _currentSceneParams = enterParams;

            _sceneLoader.LoadAndRunScene
                <TEntryPoint, TEnterParams>(enterParams);
        }
    }
}