
using System;
using Lessons.Architecture.PM;

namespace UI.Presenters
{
    public sealed class PlayerLevelProgressPresenter : IDisposable
    {
        private readonly PlayerLevel _playerLevel;
        private readonly PlayerLevelProgressView _playerLevelProgressView;

        public PlayerLevelProgressPresenter(PlayerLevel playerLevel, PlayerLevelProgressView playerLevelProgressView)
        {
            _playerLevel = playerLevel;
            _playerLevelProgressView = playerLevelProgressView;
            _playerLevel.OnExperienceChanged += ChangeExperience;
            _playerLevel.AddExperience(0);
        }
        
        private void ChangeExperience(int xp)
        {
            var maxXp = _playerLevel.RequiredExperience;
            _playerLevelProgressView.SetNewExperienceValue(xp, maxXp, _playerLevel.CanLevelUp());
        }
        
        public void Dispose()
        {
            _playerLevel.OnExperienceChanged -= ChangeExperience;
        }
    }
}
