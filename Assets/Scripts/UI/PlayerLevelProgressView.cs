using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public sealed class PlayerLevelProgressView : MonoBehaviour
    {
        [SerializeField] private Slider xpSlider;
        [SerializeField] private TextMeshProUGUI sliderText;
        [SerializeField] private Sprite normalSlider;
        [SerializeField] private Sprite finishedSlider;

        public void SetNewExperienceValue(int xp, int maxXp, bool canLevelUp)
        {
            xpSlider.maxValue = maxXp;
            xpSlider.value = xp;
            sliderText.text = $"XP: {Mathf.Min(xp, 1000)}/{maxXp}";
            xpSlider.fillRect.GetComponent<Image>().sprite = canLevelUp ? finishedSlider : normalSlider;
        }
    }
}
