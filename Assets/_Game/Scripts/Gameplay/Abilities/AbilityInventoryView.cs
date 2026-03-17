using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Abilities
{
    public class AbilityInventoryView : MonoBehaviour
    {
        [SerializeField] private RectTransform _iconsContainer;
        [SerializeField] private AbilityIcon _iconPrefab;

        public void CreateIcons(IEnumerable<AbilityIconData> icons)
        {
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