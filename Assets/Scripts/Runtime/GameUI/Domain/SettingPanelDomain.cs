using Skiing2.GameRules.Game;

namespace Skiing2.GameUI
{
    public static class SettingPanelDomain
    {
        public static void Open(GameUIContext ctx)
        {
            var panel = UIFactory.OpenPanel<SettingPanel>(ctx);
            panel.Ctor();

            panel.OnSettingsButtonClick += () =>
            {
                ctx.eventCenter.SettingButtonClickHandle();
            };
            
            panel.OnMusicSettingsButtonClick += () =>
            {
                ctx.eventCenter.MusicPanelButtonClick();
            };
            
            panel.OnCheerfulSettingsButtonClick += () =>
            {
                ctx.eventCenter.CheerfulPanelButtonClick();
            };
            
        }
        
        public static void Close(GameUIContext ctx)
        {
            UIFactory.ClosePanel<SettingPanel>(ctx);
        }

        public static void ChangeSprite(GameUIContext ctx)
        {
            var settingPanel = ctx.GetIndividualPanel<SettingPanel>();
        }
        
        public static void MusicButtonClick(GameUIContext ctx)
        {
            var settingPanel = ctx.GetIndividualPanel<SettingPanel>();
            settingPanel.IsMusicButtonClick = !settingPanel.IsMusicButtonClick;
            settingPanel.ChangeMusicButtonSprite(settingPanel.IsMusicButtonClick);
            // todo: add sound
            // GameDomain.PlaySound();
        }
        
        public static void CheerfulButtonClick(GameUIContext ctx)
        {
            var settingPanel = ctx.GetIndividualPanel<SettingPanel>();
            settingPanel.IsCheerfulButtonClick = !settingPanel.IsCheerfulButtonClick;
            settingPanel.ChangeCheerfulButtonSprite(settingPanel.IsCheerfulButtonClick);
        }
        
        
    }
}