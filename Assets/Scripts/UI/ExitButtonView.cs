using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace UI
{
    public sealed class ExitButtonView : MonoBehaviour
    {
        [SerializeField] private Button exitButton;

        public void AddListener(UnityAction action)
        {
            exitButton.onClick.AddListener(action);
        }

        public void RemoveListener(UnityAction action)
        {
            exitButton.onClick.RemoveListener(action);
        }
    }
}
