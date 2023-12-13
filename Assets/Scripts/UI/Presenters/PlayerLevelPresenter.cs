using System;
using Lessons.Architecture.PM;

namespace UI.Presenters
{
    public sealed class PlayerLevelPresenter : IDisposable
    {
        private readonly PlayerLevelIView _playerLevelIView;
        private readonly PlayerLevel _playerLevel;

        public PlayerLevelPresenter(PlayerLevelIView playerLevelIView, PlayerLevel playerLevel)
        {
            _playerLevel = playerLevel;
            _playerLevel.OnLevelUp += ChangeLevel; 
            _playerLevelIView = playerLevelIView;
            ChangeLevel();
        }

        private void ChangeLevel()
        {
            _playerLevelIView.SetPlayerLevelText($"Level: {_playerLevel.CurrentLevel}");
        }

        public void Dispose()
        {
            _playerLevel.OnLevelUp -= ChangeLevel; 
        }
    }
}
