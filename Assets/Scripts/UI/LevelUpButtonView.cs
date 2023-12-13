using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace UI
{
    public sealed class LevelUpButtonView : MonoBehaviour
    {
        [SerializeField] private Button levelUpButton;
        [SerializeField] private Sprite inactiveSprite;
        [SerializeField] private Sprite activeSprite;
        [SerializeField] private GameObject sunrise;
        
        public void AddListener(UnityAction action)
        {
            levelUpButton.onClick.AddListener(action);
        }

        public void RemoveListener(UnityAction action)
        {
            levelUpButton.onClick.RemoveListener(action);
        }

        public void ToggleButtonActiveness(bool flag)
        {
            levelUpButton.interactable = flag;
            levelUpButton.image.sprite = flag ? activeSprite : inactiveSprite;
            sunrise.SetActive(flag);
        }
    }
}
