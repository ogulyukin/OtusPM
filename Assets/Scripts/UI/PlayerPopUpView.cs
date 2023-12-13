using UnityEngine;

namespace UI
{
    public sealed class PlayerPopUpView : MonoBehaviour
    { 
        [SerializeField] private ExitButtonView exitButtonView;

        public ExitButtonView ExitButtonView => exitButtonView;

        private void Awake()
        {
            gameObject.SetActive(false);
        }
    }
}
