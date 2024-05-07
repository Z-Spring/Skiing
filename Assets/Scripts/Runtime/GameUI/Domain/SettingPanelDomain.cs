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
                ctx.eventCenter.MusicSettingsButtonClick();
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
        
        
    }
}