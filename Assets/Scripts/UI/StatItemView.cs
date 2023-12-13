using TMPro;
using UnityEngine;

namespace UI
{
    public sealed class StatItemView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI statName;

        public void SetStat(string stat, int value)
        {
            statName.text = $"{stat}: {value}";
        }
    }
}
