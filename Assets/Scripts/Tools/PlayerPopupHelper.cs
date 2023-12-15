using System.Collections.Generic;
using Lessons.Architecture.PM;
using UI;
using UI.Presenters;
using UnityEngine;
using Zenject;
using CharacterInfo = Lessons.Architecture.PM.CharacterInfo;

namespace Tools
{
    public sealed class PlayerPopupHelper : MonoBehaviour
    {
        private PlayerLevel _playerLevel;
        private UserInfo _userInfo;
        private CharacterInfo _characterInfo;
        private PlayerPopUpMainView _playerPopUpMainView;

        //Used in custom editor
        public int currentLevel;
        public string newStatName;
        public int newStatValue;
        public int xpToAdd = 100;
        public string userName = "@The great looks name";
        public string userDescription = "I am great bla bla bla! In the bla bla kingdom!";
        public Sprite userIcon;
        public readonly List<CharacterStat> CharacterStats = new();

        [Inject]
        private void Construct(PlayerPopUpMainView mainPopUpView, PlayerLevel playerLevel, UserInfo userInfo, CharacterInfo characterInfo)
        {
            _playerPopUpMainView = mainPopUpView;
            _playerLevel = playerLevel;
            _userInfo = userInfo;
            _characterInfo = characterInfo;
            currentLevel = _playerLevel.CurrentLevel;
            newStatName = "New Stat";
            newStatValue = 0;
            ViewInitializer();
        }

        public void AddNewStat()
        {
            var stat = new CharacterStat(newStatName, newStatValue);
            CharacterStats.Add(stat);
            _characterInfo.AddStat(stat);
        }

        public void RemoveStat(CharacterStat stat)
        {
            if (CharacterStats.Remove(stat))
            {
                _characterInfo.RemoveStat(stat);
            }
        }
        
        public void AddXp()
        {
            _playerLevel.AddExperience(xpToAdd);
        }

        public void ShowPopup()
        {
            if (!_playerPopUpMainView.gameObject.activeSelf)
            {
                var _ = new PlayerPopupMainPresenter(_playerPopUpMainView, _playerLevel, _userInfo, _characterInfo);
            }
        }

        public void ChangeName()
        {
            _userInfo.ChangeName(userName);
        }

        public void ChangeUserIcon()
        {
            _userInfo.ChangeIcon(userIcon);
        }

        public void ChangeUserDescription()
        {
            _userInfo.ChangeDescription(userDescription);
        }
        
        private void ViewInitializer()
        {
            ChangeName();
            ChangeUserDescription();
            ChangeUserIcon();
            AddNewStat();
            AddNewStat();
            AddNewStat();
            AddXp();
        }
    }
}
