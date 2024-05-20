using System;

namespace Runtime.GameUI
{
    public class UIEventCenter
    {
        public Action OnSettingsButtonClickHandle;
        public Action OnMusicSettingsButtonClickHandle;
        public Action OnCheerfulPanelButtonClickHandle;

        public void SettingButtonClickHandle()
        {
            OnSettingsButtonClickHandle?.Invoke();
        }

        public void MusicPanelButtonClick()
        {
            OnMusicSettingsButtonClickHandle?.Invoke();
        }

        public void CheerfulPanelButtonClick()
        {
            OnCheerfulPanelButtonClickHandle?.Invoke();
        }
    }
}