using Lessons.Architecture.PM;
using Tools;
using UI;
using UnityEngine;
using Zenject;
using CharacterInfo = Lessons.Architecture.PM.CharacterInfo;

namespace Core
{
    public sealed class LevelInstaller : MonoInstaller
    {
        [SerializeField] private PlayerPopupHelper helper;
        [SerializeField] private PlayerPopUpMainView playerPopUpMainView;
        public override void InstallBindings()
        {
            Container.Bind<PlayerPopupHelper>().FromInstance(helper).AsSingle();
            Container.Bind<PlayerLevel>().AsSingle();
            Container.Bind<CharacterInfo>().AsSingle();
            Container.Bind<UserInfo>().AsSingle();
            Container.Bind<PlayerPopUpMainView>().FromInstance(playerPopUpMainView).AsSingle();
        }
    }
}