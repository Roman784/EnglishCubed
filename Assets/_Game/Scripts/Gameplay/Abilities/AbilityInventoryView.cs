using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Abilities
{
    public class AbilityInventoryView : MonoBehaviour
    {
        [SerializeField] private RectTransform _iconsContainer;
        [SerializeField] private AbilityIcon _iconPrefab;

        public void DisplayAbilities(IEnumerable<AbilityIconData> icons)
        {
            if (icons == null || icons.Count() == 0) return;

            ClearContainer();

            foreach (var iconData in icons)
            {
                var createIcon = Instantiate(_iconPrefab, _iconsContainer, false);
                createIcon.Set(iconData);
            }
        }

        private void ClearContainer()
        {
            var childsCount = _iconsContainer.childCount;
            for (int i = 0; i < childsCount; i++)
            {
                Destroy(_iconsContainer.GetChild(i).gameObject);
            }
        }
    }
}