using Skiing2.GameUI;

namespace Skiing2.GameRules
{
    public class UIBusiness
    {
        public static void Enter(UIBusinessContext ctx)
        {
            UI.SettingPanelOpen(ctx.gameUIContext);
        }

        public static void Exit(UIBusinessContext ctx)
        {
            UI.SettingPanelClose(ctx.gameUIContext);
        }

        public static void OnSettingButtonClick(UIBusinessContext ctx)
        {
            var settingPanel = ctx.gameUIContext.GetIndividualPanel<SettingPanel>();
            settingPanel.SecondPanelActive(!settingPanel.IsSecondPanelActive);
        }

        public static void OnMusicButtonClick(UIBusinessContext ctx)
        {
            SettingPanelDomain.MusicButtonClick(ctx.gameUIContext);
        }

        public static void OnCheerfulButtonClick(UIBusinessContext ctx)
        {
            SettingPanelDomain.CheerfulButtonClick(ctx.gameUIContext);
        }

        public static void TearDown(UIBusinessContext ctx)
        {
            Exit(ctx);
        }
    }
}