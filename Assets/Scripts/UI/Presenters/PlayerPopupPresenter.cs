using System;
using Lessons.Architecture.PM;

namespace UI.Presenters
{
    public sealed class PlayerPopupPresenter: IDisposable
    {
        private readonly PlayerPopUpView _playerPopUpView;
        private readonly PlayerLevel _playerLevel;

        public PlayerPopupPresenter(PlayerPopUpView popUpView)
        {
            _playerPopUpView = popUpView;
            _playerPopUpView.ExitButtonView.AddListener(ClosePopup);
        }

        public void ShowPlayerPopup(bool flag)
        {
            _playerPopUpView.gameObject.SetActive(flag);
        }

        private void ClosePopup()
        {
            ShowPlayerPopup(false);
        }

        public void Dispose()
        {
            _playerPopUpView.ExitButtonView.RemoveListener(ClosePopup);
        }
    }
}
