using Lessons.Architecture.PM;
using Tools;
using UnityEngine;
using Zenject;
using CharacterInfo = Lessons.Architecture.PM.CharacterInfo;

namespace Core
{
    public sealed class LevelInstaller : MonoInstaller
    {
        [SerializeField] private PlayerPopupHelper helper;
        public override void InstallBindings()
        {
            Container.Bind<PlayerPopupHelper>().FromInstance(helper).AsSingle();
            Container.Bind<PlayerLevel>().AsSingle();
            Container.Bind<CharacterInfo>().AsSingle();
            Container.Bind<UserInfo>().AsSingle();
        }
    }
}