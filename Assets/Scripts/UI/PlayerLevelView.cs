using TMPro;
using UnityEngine;

namespace UI
{
    public sealed class PlayerLevelView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI levelText;

        public void SetPlayerLevelText(string text)
        {
            levelText.text = text;
        }
    }
}
