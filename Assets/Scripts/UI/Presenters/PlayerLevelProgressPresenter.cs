using Lessons.Architecture.PM;
using UnityEngine;

namespace UI.Presenters
{
    public sealed class PlayerLevelProgressPresenter : IChildPresenter
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
            _playerLevelProgressView.SetNewExperienceValue(xp, maxXp, $"XP: {Mathf.Min(xp, 1000)}/{maxXp}", _playerLevel.CanLevelUp());
        }
        
        public void CloseView()
        {
            _playerLevel.OnExperienceChanged -= ChangeExperience;
        }
    }
}
