using Lessons.Architecture.PM;

namespace UI.Presenters
{
    public sealed class LevelUpButtonPresenter : IChildPresenter
    {
        private readonly LevelUpButtonView _levelUpButtonView;
        private readonly PlayerLevel _playerLevel;
        
        public LevelUpButtonPresenter(LevelUpButtonView levelUpButtonView, PlayerLevel playerLevel)
        {
            _levelUpButtonView = levelUpButtonView;
            _playerLevel = playerLevel;
            _playerLevel.OnExperienceChanged += ChangeExperience;
            _levelUpButtonView.AddListener(OnLevelButtonClick);
        }

        private void OnLevelButtonClick()
        {
            if (!_playerLevel.CanLevelUp())
            {
                return;
            }
            _playerLevel.LevelUp();
        }

        private void ChangeExperience(int _)
        {
            _levelUpButtonView.ToggleButtonActiveness(_playerLevel.CanLevelUp());
        }

        public void CloseView()
        {
            _playerLevel.OnExperienceChanged += ChangeExperience;
            _levelUpButtonView.RemoveListener(OnLevelButtonClick);
        }
    }
}
