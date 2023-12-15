using Lessons.Architecture.PM;

namespace UI.Presenters
{
    public sealed class PlayerLevelPresenter : IChildPresenter
    {
        private readonly PlayerLevelView _playerLevelView;
        private readonly PlayerLevel _playerLevel;

        public PlayerLevelPresenter(PlayerLevelView playerLevelView, PlayerLevel playerLevel)
        {
            _playerLevel = playerLevel;
            _playerLevel.OnLevelUp += ChangeLevel; 
            _playerLevelView = playerLevelView;
            ChangeLevel();
        }

        private void ChangeLevel()
        {
            _playerLevelView.SetPlayerLevelText($"Level: {_playerLevel.CurrentLevel}");
        }
        
        public void CloseView()
        {
            _playerLevel.OnLevelUp -= ChangeLevel; 
        }
    }
}
