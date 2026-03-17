using System.Net.NetworkInformation;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Abilities
{
    public class AbilityIcon : MonoBehaviour
    {
        [SerializeField] private Image _iconView;
        [SerializeField] private TMP_Text _stacksView;

        public void Set(AbilityIconData data)
        {
            if (data.StacksCount <= 0) _stacksView.gameObject.SetActive(false);

            _iconView.sprite = data.Icon;
            _stacksView.text = data.IsMaxStacks ? "max" : data.StacksCount.ToString();
        }
    }
}