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

        public void SetNewExperienceValue(int xp, int maxXp , string textForSlider, bool canLevelUp)
        {
            xpSlider.maxValue = maxXp;
            xpSlider.value = xp;
            sliderText.text = textForSlider;
            xpSlider.fillRect.GetComponent<Image>().sprite = canLevelUp ? finishedSlider : normalSlider;
        }
    }
}
