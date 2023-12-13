using UI;
using UI.Presenters;
using UnityEngine;
using Zenject;

namespace Core
{
    public sealed class PlayerPopUpInstaller : MonoInstaller
    {
        [SerializeField] private PlayerPopUpView playerPopUpView;
        [SerializeField] private PlayerLevelIView playerLevelIView;
        [SerializeField] private PlayerInfoView playerInfoView;
        [SerializeField] private PlayerStatsView playerStatsView;
        [SerializeField] private LevelUpButtonView levelUpButtonView;
        [SerializeField] private PlayerLevelProgressView playerLevelProgressView;
        public override void InstallBindings()
        {
            BindPlayerPopupView();
            BindPlayerPopupPresenters();
        }
    
        private void BindPlayerPopupView()
        {
            Container.Bind<PlayerPopUpView>().FromInstance(playerPopUpView).AsSingle();
            Container.Bind<PlayerLevelIView>().FromInstance(playerLevelIView).AsSingle();
            Container.Bind<PlayerInfoView>().FromInstance(playerInfoView).AsSingle();
            Container.Bind<PlayerStatsView>().FromInstance(playerStatsView).AsSingle();
            Container.Bind<LevelUpButtonView>().FromInstance(levelUpButtonView).AsSingle();
            Container.Bind<PlayerLevelProgressView>().FromInstance(playerLevelProgressView).AsSingle();
        }

        private void BindPlayerPopupPresenters()
        {
            Container.BindInterfacesAndSelfTo<PlayerPopupPresenter>().AsSingle();
            Container.BindInterfacesAndSelfTo<PlayerLevelPresenter>().AsSingle();
            Container.BindInterfacesAndSelfTo<PlayerInfoPresenter>().AsSingle();
            Container.BindInterfacesAndSelfTo<PlayerStatsPresenter>().AsSingle();
            Container.BindInterfacesAndSelfTo<LevelUpButtonPresenter>().AsSingle();
            Container.BindInterfacesAndSelfTo<PlayerLevelProgressPresenter>().AsSingle();
        }
    }
}