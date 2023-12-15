using System.Collections.Generic;
using Lessons.Architecture.PM;

namespace UI.Presenters
{
    public sealed class PlayerPopupMainPresenter
    {
        private readonly PlayerPopUpMainView _playerPopUpMainView;
        private readonly PlayerLevel _playerLevel;
        private readonly ExitButtonPresenter _exitButtonPresenter;
        private readonly List<IChildPresenter> _presenters = new();

        public PlayerPopupMainPresenter(PlayerPopUpMainView popUpMainView, PlayerLevel playerLevel, UserInfo info, CharacterInfo characterInfo)
        {
            _playerPopUpMainView = popUpMainView;
            _exitButtonPresenter = new ExitButtonPresenter(_playerPopUpMainView.ExitButtonView);
            _exitButtonPresenter.OnExitButton += ClosePopup;
            _presenters.Add(_exitButtonPresenter);
            _playerPopUpMainView.gameObject.SetActive(true);
            var levelUpButtonPresenter = new LevelUpButtonPresenter(_playerPopUpMainView.LevelUpButtonView, playerLevel);
            _presenters.Add(levelUpButtonPresenter);
            var playerInfoPresenter = new PlayerInfoPresenter(_playerPopUpMainView.PlayerInfoView, info);
            _presenters.Add(playerInfoPresenter);
            var playerLevelPresenter = new PlayerLevelPresenter(_playerPopUpMainView.PlayerLevelView, playerLevel);
            _presenters.Add(playerLevelPresenter);
            var playerLevelProgressPresenter =
                new PlayerLevelProgressPresenter(playerLevel, _playerPopUpMainView.PlayerLevelProgressView);
            _presenters.Add(playerLevelProgressPresenter);
            var playerStatPresenter = new PlayerStatsPresenter(_playerPopUpMainView.PlayerStatsView, characterInfo);
            _presenters.Add(playerStatPresenter);
        }

        private void ClosePopup()
        {
            _playerPopUpMainView.gameObject.SetActive(false);
            _playerPopUpMainView.ExitButtonView.RemoveListener(ClosePopup);
            _exitButtonPresenter.OnExitButton -= ClosePopup;
            foreach (var presenter in _presenters)
            {
                presenter.CloseView();
            }
        }
    }
}
