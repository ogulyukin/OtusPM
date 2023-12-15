using Lessons.Architecture.PM;

namespace UI.Presenters
{
    public sealed class PlayerStatsPresenter : IChildPresenter
    {
        private readonly PlayerStatsView _playerStatsView;
        private readonly CharacterInfo _characterInfo;

        public PlayerStatsPresenter(PlayerStatsView playerStatsView, CharacterInfo characterInfo)
        {
            _playerStatsView = playerStatsView;
            _characterInfo = characterInfo;
            _characterInfo.OnStatAdded += AddStat;
            _characterInfo.OnStatRemoved += RemoveStat;
            RedrawStats();
        }

        private void AddStat(CharacterStat stat)
        {
            stat.OnValueChanged += RedrawStats;
            RedrawStats();
        }
        
        private void RemoveStat(CharacterStat stat)
        {
            stat.OnValueChanged -= RedrawStats;
            RedrawStats();
        }
        
        private void RedrawStats()
        {
            _playerStatsView.RedrawStats(_characterInfo.GetStats());
        }
        private void RedrawStats(int _)
        {
           RedrawStats();
        }
        
        public void CloseView()
        {
            _characterInfo.OnStatAdded -= AddStat;
            _characterInfo.OnStatRemoved -= RemoveStat;
        }
    }
}
