using System;
using Lessons.Architecture.PM;
using UnityEngine;

namespace UI.Presenters
{
    public sealed class PlayerInfoPresenter : IDisposable
    {
        private readonly PlayerInfoView _playerInfoView;
        private readonly UserInfo _userInfo;

        public PlayerInfoPresenter(PlayerInfoView playerInfoView, UserInfo userInfo)
        {
            _playerInfoView = playerInfoView;
            _userInfo = userInfo;
            _userInfo.OnNameChanged += ChangeName;
            _userInfo.OnDescriptionChanged += ChangeDescription;
            _userInfo.OnIconChanged += ChangeUserIcon;
        }
        
        private void ChangeName(string name)
        {
            _playerInfoView.ChangeName(name);
        }

        private void ChangeDescription(string description)
        {
            _playerInfoView.ChangeUserDescription(description);
        }

        private void ChangeUserIcon(Sprite icon)
        {
            _playerInfoView.ChangeUserIcon(icon);
        }

        public void Dispose()
        {
            _userInfo.OnNameChanged -= ChangeName;
            _userInfo.OnDescriptionChanged -= ChangeDescription;
            _userInfo.OnIconChanged -= ChangeUserIcon;
        }
    }
}
