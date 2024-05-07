using System;
using UnityEngine;
using UnityEngine.UI;

namespace Skiing2.GameUI
{
    public class SettingPanel : MonoBehaviour
    {
        [SerializeField] SettingImages[] settingsImages;


        public Action OnSettingsButtonClick;
        public Action OnMusicSettingsButtonClick;
        public Action OnCheerfulSettingsButtonClick;

        GameObject settingsPanel;
        Button settingsButton;
        GameObject secondPanel;
        Button musicSettingsButton;
        Button cheerfulSettingsButton;
        Image musicButtonBackground;
        Image cheerfulButtonBackground;
        Image musicButtonChildImage;
        Image cheerfulButtonChildImage;


        public void Ctor()
        {
            // Get components
            settingsButton = transform.GetChild(0).GetComponent<Button>();

            secondPanel = transform.GetChild(1).gameObject;
            musicSettingsButton = secondPanel.transform.GetChild(0).GetComponent<Button>();
            cheerfulSettingsButton = secondPanel.transform.GetChild(1).GetComponent<Button>();

            musicButtonBackground = musicSettingsButton.GetComponent<Image>();
            cheerfulButtonBackground = cheerfulSettingsButton.GetComponent<Image>();
            musicButtonChildImage = musicSettingsButton.transform.GetChild(0).GetComponent<Image>();
            cheerfulButtonChildImage = cheerfulSettingsButton.transform.GetChild(0).GetComponent<Image>();

            // Add listeners
            settingsButton.onClick.AddListener(() => { OnSettingsButtonClick?.Invoke(); });
            musicSettingsButton.onClick.AddListener(() => { OnMusicSettingsButtonClick?.Invoke(); });
            cheerfulSettingsButton.onClick.AddListener(() => { OnCheerfulSettingsButtonClick?.Invoke(); });
        }

        public void ChangeOpenSettingSprite(Sprite sprite)
        {
            // Change sprite

            musicButtonBackground.sprite = sprite;
        }


        public void HideSettings()
        {
            settingsPanel.SetActive(false);
        }

        public void ShowSettings()
        {
            settingsPanel.SetActive(true);
        }

        public void ShowSecondPanel()
        {
            secondPanel.SetActive(true);
        }

        public void HideSecondPanel()
        {
            secondPanel.SetActive(false);
        }

        void OnDestroy()
        {
            settingsButton.onClick.RemoveAllListeners();
            musicSettingsButton.onClick.RemoveAllListeners();
            cheerfulSettingsButton.onClick.RemoveAllListeners();
            
            OnSettingsButtonClick = null;
            OnMusicSettingsButtonClick = null;
            OnCheerfulSettingsButtonClick = null;
        }
    }
}