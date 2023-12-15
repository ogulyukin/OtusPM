using UnityEngine;

namespace UI
{
    public sealed class PlayerPopUpMainView : MonoBehaviour
    { 
        [SerializeField] private ExitButtonView exitButtonView;
        [SerializeField] private PlayerInfoView playerInfoView;
        [SerializeField] private PlayerLevelView playerLevelView;
        [SerializeField] private PlayerLevelProgressView playerLevelProgressView;
        [SerializeField] private LevelUpButtonView levelUpButtonView;
        [SerializeField] private PlayerStatsView playerStatsView;

        public ExitButtonView ExitButtonView => exitButtonView;
        
        public PlayerInfoView PlayerInfoView => playerInfoView;

        public PlayerLevelView PlayerLevelView => playerLevelView;

        public PlayerLevelProgressView PlayerLevelProgressView => playerLevelProgressView;

        public LevelUpButtonView LevelUpButtonView => levelUpButtonView;

        public PlayerStatsView PlayerStatsView => playerStatsView;

        private void Awake()
        {
            gameObject.SetActive(false);
        }
    }
}
