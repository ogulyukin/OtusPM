using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public sealed class PlayerInfoView : MonoBehaviour
    {
        [SerializeField] private Image playerIcon;
        [SerializeField] private TextMeshProUGUI playerDescription;
        [SerializeField] private TextMeshProUGUI userName;

        public void ChangeName(string user)
        {
            userName.text = user;
        }

        public void ChangeUserDescription(string info)
        {
            playerDescription.text = info;
        }

        public void ChangeUserIcon(Sprite icon)
        {
            playerIcon.sprite = icon;
        }
        
    }
}
