using AbilityMenu;
using HeroMenu;
using LevelMenu;
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
            OpenScene<MainMenuEntryPoint, MainMenuEnterParams>(enterParams);
        }

        public void OpenLevelMenu()
        {
            var enterParams = new LevelMenuEnterParams();
            OpenScene<LevelMenuEntryPoint, LevelMenuEnterParams>(enterParams);
        }
        public void OpenAbilityMenu()
        {
            var enterParams = new AbilityMenuEnterParams();
            OpenScene<AbilityMenuEntryPoint, AbilityMenuEnterParams>(enterParams);
        }

        public void OpenHeroMenu()
        {
            var enterParams = new HeroMenuEnterParams();
            OpenScene<HeroMenuEntryPoint, HeroMenuEnterParams>(enterParams);
        }

        public void OpenTestRoom()
        {
            var enterParams = new TestRoomEnterParams();
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