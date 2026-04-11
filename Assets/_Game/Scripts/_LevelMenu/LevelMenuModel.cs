using Gameplay;
using GameRoot;

namespace LevelMenu
{
    public class LevelMenuModel
    {
        public CreatureName SelectedHero => G.Repository.MetaProgression.GetSelectedHero();
    }
}