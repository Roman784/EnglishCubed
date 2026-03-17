using Configs;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Abilities
{
    public class AbilityInventoryPresentor    
    {
        private AbilityInventoryView _view;
        private AbilityInventoryModel _model;

        public AbilityInventoryPresentor(AbilityInventoryView view, AbilityInventoryModel model)
        {
            _view = view;
            _model = model;
        }

        public void AddAbility(AbilityName abilityName)
        {
            var abilityLevelData = _model.AddAbility(abilityName);
            if (abilityLevelData == null) return;

            // TODO: Apply ability.

            RefreshView();
        }

        private void RefreshView()
        {
            _view.RefreshIcons(_model.GetAbilityIconsData());
        }
    }
}