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
        
        public bool IsSecondPanelActive => secondPanel.activeSelf;
        public bool IsMusicButtonClick { get; set; } = true;
        public bool IsCheerfulButtonClick { get; set; } = true;

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
        
        public void ChangeMusicButtonSprite(bool isClick)
        {
            if (isClick)
            {
                musicButtonChildImage.sprite = settingsImages[0].music;
                musicButtonBackground.sprite = settingsImages[0].background;
            }
            else
            {
                musicButtonChildImage.sprite = settingsImages[1].music;
                musicButtonBackground.sprite = settingsImages[1].background;
            }
        }
        
        public void ChangeCheerfulButtonSprite(bool isClick)
        {
            if (isClick)
            {
                cheerfulButtonChildImage.sprite = settingsImages[0].cheerful;
                cheerfulButtonBackground.sprite = settingsImages[0].background;
            }
            else
            {
                cheerfulButtonChildImage.sprite = settingsImages[1].cheerful;
                cheerfulButtonBackground.sprite = settingsImages[1].background;
            }
        }


        public void HideSettings()
        {
            settingsPanel.SetActive(false);
        }

        public void ShowSettings()
        {
            settingsPanel.SetActive(true);
        }

        public void SecondPanelActive(bool active)
        {
            secondPanel.SetActive(active);
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