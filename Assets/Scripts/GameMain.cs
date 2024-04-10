using System;
using System.Threading.Tasks;
using Cinemachine;
using Skiing2.GameRules;
using Skiing2.GameRules.Game;
using Skiing2.Runtime.Common;
using UnityEngine;
using UnityEngine.UI;

namespace Skiing2
{
    public class GameMain : MonoBehaviour
    {
        [SerializeField] Button startButton;

        // Context
        AssetsInfraContext assetsInfraContext;
        TemplateInfraContext templateInfraContext;
        GameBusinessContext gameBusinessContext;

        // Controller
        PlayerController playerController;
        EnemyController enemyController;

        CinemachineVirtualCamera followCamera;
        Camera mainCamera;
        GameObject background;


        bool isTearDown;
        int playerLayer;
        bool isStartGame;

        void Start()
        {
            background = GameObject.Find("Background");
            followCamera = GameObject.Find("FollowCamera").GetComponent<CinemachineVirtualCamera>();
            mainCamera = Camera.main;
            playerLayer = 1 << LayerMask.NameToLayer("Player");


            startButton.onClick.AddListener(() =>
            {
                GameBusiness.StartGame(gameBusinessContext);
                startButton.gameObject.SetActive(false);
            });

            assetsInfraContext = new AssetsInfraContext();
            templateInfraContext = new TemplateInfraContext();

            gameBusinessContext = new GameBusinessContext
            {
                background = background,
                followCamera = followCamera,
                mainCamera = mainCamera,
                playerLayer = playerLayer,
                templateInfraContext = templateInfraContext,
                assetsInfraContext = assetsInfraContext,
            };

            gameBusinessContext.gameEntity.GameFSMComponent.state = GameState.None;

            // Controller
            playerController = new PlayerController();
            enemyController = new EnemyController();

            Action action = async () =>
            {
                try
                {
                    await LoadAssets();
                }
                catch (Exception e)
                {
                    Debug.LogError(e.ToString());
                }
            };
            action.Invoke();
        }

        void Update()
        {
            if (isTearDown) return;
            if (gameBusinessContext.gameEntity.GameFSMComponent.state != GameState.Start) return;
            playerController.Tick(gameBusinessContext);
            enemyController.Tick(gameBusinessContext);
        }

        void OnApplicationQuit()
        {
            TearDown();
            Application.Quit();
        }

        void OnDestroy()
        {
            TearDown();
        }

        void TearDown()
        {
            if (isTearDown) return;
            isTearDown = true;
            GameBusiness.TearDown(gameBusinessContext);
            AssetsInfra.ReleaseAssets(assetsInfraContext);
            TemplateInfra.Release(templateInfraContext);
        }

        async Task LoadAssets()
        {
            await AssetsInfra.LoadAssets(assetsInfraContext);
            await TemplateInfra.LoadAssets(templateInfraContext);
        }
    }
}