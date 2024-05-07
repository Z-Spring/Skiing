using System;
using System.Threading.Tasks;
using Cinemachine;
using Skiing2.GameRules;
using Skiing2.GameRules.Game;
using UnityEngine;
using UnityEngine.UI;

namespace Skiing2
{
    public class GameMain : MonoBehaviour
    {
        [SerializeField] Button startButton;
        [SerializeField] Button musicButton;

        [SerializeField] int initSlimeNum;

        // Context
        AssetsInfraContext assetsInfraContext;
        TemplateInfraContext templateInfraContext;
        GameBusinessContext gameBusinessContext;
        UIBusinessContext uiBusinessContext;
        GameUIContext gameUIContext;

        // Controller
        PlayerController playerController;
        EnemyController enemyController;

        CinemachineVirtualCamera followCamera;
        Camera mainCamera;
        GameObject background;
        Transform slimeParent;
        Transform playerTrail;
        Transform Bgm;
        ParticleSystem flareEffect;
        ParticleSystem smokeEffect;
        ParticleSystem confettiEffect;
        Canvas canvas;

        bool isTearDown;
        int playerLayer;
        bool isStartGame;

        void Start()
        {
            background = GameObject.Find("Background");
            followCamera = GameObject.Find("FollowCamera").GetComponent<CinemachineVirtualCamera>();
            mainCamera = Camera.main;
            playerLayer = 1 << LayerMask.NameToLayer("Player");
            slimeParent = GameObject.Find("SlimePool").transform;
            playerTrail = GameObject.Find("PlayerTrail").transform;
            flareEffect = GameObject.Find("FlareEffect").transform.GetComponent<ParticleSystem>();
            smokeEffect = GameObject.Find("SmokeEffect").transform.GetComponent<ParticleSystem>();
            confettiEffect = GameObject.Find("ConfettiEffect").transform.GetComponent<ParticleSystem>();
            Bgm = GameObject.Find("Bgm").transform;
            canvas = GameObject.Find("MainCanvas").GetComponent<Canvas>();

            startButton.onClick.AddListener(() =>
            {
                GameBusiness.StartGame(gameBusinessContext);
                startButton.gameObject.SetActive(false);
            });

            musicButton.onClick.AddListener(() =>
            {
                gameBusinessContext.isPlaySound = !gameBusinessContext.isPlaySound;
                GameBusiness.PlaySound(gameBusinessContext);
            });


            assetsInfraContext = new AssetsInfraContext();
            templateInfraContext = new TemplateInfraContext();
            gameUIContext = new GameUIContext
            {
                canvas = canvas,
            };

            gameBusinessContext = new GameBusinessContext
            {
                background = background,
                followCamera = followCamera,
                mainCamera = mainCamera,
                playerLayer = playerLayer,
                templateInfraContext = templateInfraContext,
                assetsInfraContext = assetsInfraContext,
                slimeParent = slimeParent,
                startSlimeCount = initSlimeNum,
                monoBehaviour = this,
                nextSpawnY = mainCamera.transform.position.y - mainCamera.orthographicSize * 2,
                playerTrail = playerTrail,
                flareEffect = flareEffect,
                smokeEffect = smokeEffect,
                confettiEffect = confettiEffect,
                Bgm = Bgm,
            };

            uiBusinessContext = new UIBusinessContext
            {
                gameUIContext = gameUIContext,
            };

            gameBusinessContext.gameEntity.GameFSMComponent.state = GameState.None;

            // Controller
            playerController = new PlayerController();
            enemyController = new EnemyController();


            BindEvents();
            Action action = async () =>
            {
                try
                {
                    await LoadAssets();
                    Init();
                    Enter();
                }
                catch (Exception e)
                {
                    Debug.LogError(e.ToString());
                }
            };
            action.Invoke();
        }


        void Init()
        {
            Application.targetFrameRate = 60;
            enemyController.Init(gameBusinessContext);

            GameBusiness.Init(gameBusinessContext);
        }

        void Enter()
        {
            UIBusiness.Enter(uiBusinessContext);
        }

        void BindEvents()
        {
            // Bind events
            GameEventCenter.OnWinGame += GameBusiness.WinGame;
            GameEventCenter.OnFailGame += GameBusiness.FailGame;

            var evt = gameUIContext.eventCenter;
            evt.OnSettingsButtonClickHandle += () => { UIBusiness.OnSettingButtonClick(uiBusinessContext); };
        }

        void Update()
        {
            if (isTearDown) return;
            playerController.Tick(gameBusinessContext);
            enemyController.Tick(gameBusinessContext);
        }

        // todo: FixedUpdate is should modify
        void FixedUpdate()
        {
            if (isTearDown) return;
            playerController.FixedTick(gameBusinessContext);
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
            UIBusiness.TearDown(uiBusinessContext);
            AssetsInfra.ReleaseAssets(assetsInfraContext);
            TemplateInfra.Release(templateInfraContext);
            UnBindEvents();
        }

        async Task LoadAssets()
        {
            await UI.LoadAssets(gameUIContext);
            await AssetsInfra.LoadAssets(assetsInfraContext);
            await TemplateInfra.LoadAssets(templateInfraContext);
        }

        void UnBindEvents()
        {
            GameEventCenter.OnWinGame -= GameBusiness.WinGame;
            GameEventCenter.OnFailGame -= GameBusiness.FailGame;
        }
    }
}