
using System;
using Lessons.Architecture.PM;

namespace UI.Presenters
{
    public sealed class LevelUpButtonPresenter : IDisposable
    {
        private LevelUpButtonView _levelUpButtonView;
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
            if (_playerLevel.CanLevelUp())
            {
                _levelUpButtonView.ToggleButtonActiveness(true);
            }
            else
            {
                _levelUpButtonView.ToggleButtonActiveness(false);
            }
        }

        public void Dispose()
        {
            _playerLevel.OnExperienceChanged += ChangeExperience;
            _levelUpButtonView.RemoveListener(OnLevelButtonClick);
        }
    }
}
