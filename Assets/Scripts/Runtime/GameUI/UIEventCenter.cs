using System;

namespace Runtime.GameUI
{
    public class UIEventCenter
    {
        public Action OnSettingsButtonClickHandle;

        public void SettingButtonClickHandle()
        {
            OnSettingsButtonClickHandle?.Invoke();
        }

        public Action OnMusicSettingsButtonClickHandle;

        public void MusicSettingsButtonClick()
        {
            OnMusicSettingsButtonClickHandle?.Invoke();
        }

        public Action OnCheerfulPanelButtonClickHandle;

        public void CheerfulPanelButtonClick()
        {
            OnCheerfulPanelButtonClickHandle?.Invoke();
        }
    }
}