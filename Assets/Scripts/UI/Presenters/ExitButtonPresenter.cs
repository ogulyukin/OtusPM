using System;

namespace UI.Presenters
{
    public sealed class ExitButtonPresenter : IChildPresenter
    {
        public Action OnExitButton;
        private readonly ExitButtonView _exitButtonView;

        public ExitButtonPresenter(ExitButtonView view)
        {
            _exitButtonView = view;
            _exitButtonView.AddListener(ClosePopup);
        }
        
        private void ClosePopup()
        {
            OnExitButton?.Invoke();
        }

        public void CloseView()
        {
            _exitButtonView.RemoveListener(ClosePopup);
        }
    }
}
