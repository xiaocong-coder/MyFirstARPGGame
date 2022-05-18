using System;
using System.Collections.Generic;
using AssetsPackage.Scripts.Game.BackState_Moduels;
using AssetsPackage.Scripts.Game.CustomClasses.LevelStates;
using AssetsPackage.Scripts.Game.CustomClasses.UI;
using AssetsPackage.Scripts.Game.Systems.InitizeSystems;
using AssetsPackage.Scripts.SceneModel;
using AssetsPackage.Scripts.Tool;
using AssetsPackage.Scripts.Utils;
using UnityEngine;
using UnityEngine.Rendering;

namespace AssetsPackage.Scripts.Game.Worlds
{
    public class LevelMap : ARPGWorld
    {
        public override void Awake()
        {
            base.Awake();
            
            InitEntitiesList();
            InitSinglCompEntity();
            InitStateMachine();
            InitCamera(InitCubeHunter());
            InitEnemy();
            InitUIContainer();
            InitUI();
        }

        private void InitEntitiesList()
        {
            this.EntitiesList = new Dictionary<int, ARPGEntity>();
        }
        
        private void InitStateMachine()
        {
            this.AllLevelStates = new Dictionary<Type, ARPGState>()
            {
                { typeof(LLoadState),   new LLoadState() },
                { typeof(LPlayState),   new LPlayState() },
                { typeof(LStoryState),  new LStoryState() },
                { typeof(LPauseState),  new LPauseState() },
                { typeof(LWindUpState), new LWindUpState() }
            };
            CurrentState = ARPGState.DefaultState;
            ARPGState.ChangeState(ref CurrentState, AllLevelStates[typeof(LLoadState)]);
        }

        private void InitSinglCompEntity()
        {
            var entitiesGroupID = ARPGEntitiesGroupID.SingCompManager;
            ARPGEntity SingCompManagerEntity = new ARPGEntity(null);
            var compoments = ARPGCompomentsGenerator.GetLevelSingCompManagerCompoment(this.transform);
            SingCompManagerEntity.SetCompoments(compoments);
            
            this.EntitiesList.Add(SingCompManagerEntity.EntityID, SingCompManagerEntity);
            this.EntitiesGroup.AddEntityToGroup(entitiesGroupID, SingCompManagerEntity);
        }
        
        private Transform InitCubeHunter()
        {
            var startPosition = this.transform.Find("PlayerStartPosition");
            var charactorObject = WorldGod.Singleton.LoadMainCharactor<GameObject>("CubeHunter");
            charactorObject.transform.parent = this.transform;
            charactorObject.transform.position = startPosition.position;

            var entitiesGroupID = ARPGEntitiesGroupID.CubeHunterGroupID;
            ARPGEntity MainCharactorEntity = new ARPGEntity(charactorObject);
            var compoments = ARPGCompomentsGenerator.GetCubeHunterCompoments(charactorObject, MainCharactorEntity.EntityID);
            MainCharactorEntity.SetCompoments(compoments);
            
            ARPGPropertiesSetter.SetCubeHunterProperties(ref MainCharactorEntity);

            this.EntitiesList.Add(MainCharactorEntity.EntityID, MainCharactorEntity);
            this.EntitiesGroup.AddEntityToGroup(entitiesGroupID, MainCharactorEntity);

            return charactorObject.transform;
        }
        
        private void InitEnemy()
        {
            var levelName = this.name;
            var enemyNums = ExcelLoader.Singleton.GetEnemyNums(levelName);

            var spawn = this.transform.Find("EnemyStartPosition").GetComponent<SpawnZone>();

            var entitiesGroupID = ARPGEntitiesGroupID.CubeGroupID;
            for (int i = 0; i < enemyNums; i++)
            {
                var position = spawn.SpawnPoint;

                var enemyObject = WorldGod.Singleton.LoadEnemy<GameObject>("NormalCube");
                enemyObject.transform.parent = this.transform;
                enemyObject.transform.position = position;
                enemyObject.name = "NormalCube" + i;

                ARPGEntity EnenmyEntity = new ARPGEntity(enemyObject);
                var compoments = ARPGCompomentsGenerator.GetNormalCubeCompoments(enemyObject, EnenmyEntity.EntityID);
                EnenmyEntity.SetCompoments(compoments);
                
                ARPGPropertiesSetter.SetNormalCubeProperties(ref EnenmyEntity);
                
                this.EntitiesList.Add(EnenmyEntity.EntityID, EnenmyEntity);
                this.EntitiesGroup.AddEntityToGroup(entitiesGroupID, EnenmyEntity);
            }
        }
        
        private void InitCamera(Transform transform)
        {
            var camera = Camera.main;

            var entitiesGroupID = ARPGEntitiesGroupID.CameraGroupID;
            ARPGEntity CameraEntity = new ARPGEntity(camera.gameObject);
            var compoments = ARPGCompomentsGenerator.GetMainCameraCompoments(camera, transform.gameObject, CameraEntity.EntityID);
            CameraEntity.SetCompoments(compoments);
            
            this.EntitiesList.Add(CameraEntity.EntityID, CameraEntity);
            this.EntitiesGroup.AddEntityToGroup(entitiesGroupID, CameraEntity);
        }

        private void InitUIContainer()
        {
            var uiContainer = new GameObject("UIContainer");
            uiContainer.transform.parent = this.transform;

            var entitiesGroupID = ARPGEntitiesGroupID.UIContainerGroupID;
            var uiContainerEntity = new ARPGEntity(uiContainer);
            var compoments = ARPGCompomentsGenerator.GetUIContainerCompoments(uiContainer, uiContainerEntity.EntityID);
            uiContainerEntity.SetCompoments(compoments);
            
            this.EntitiesList.Add(uiContainerEntity.EntityID, uiContainerEntity);
            this.EntitiesGroup.AddEntityToGroup(entitiesGroupID, uiContainerEntity);
        }
        
        private void InitUI()
        {
            var uiContainer = FindGameObject.GetTransformInChildByName("UIContainer", this.transform);
            
            var playUIObj = WorldGod.Singleton.LoadUI<GameObject>("PlayUI");
            var playUI = new PlayUI(uiContainer, playUIObj);
            
            var pauseUIObj = WorldGod.Singleton.LoadUI<GameObject>("PauseUI");
            var pauseUI = new PauseUI(uiContainer, pauseUIObj);
            
            var windUpUIObj = WorldGod.Singleton.LoadUI<GameObject>("WindUpUI");
            var windUpUI = new WindUpUI(uiContainer, windUpUIObj);
            
            var storyUIObj = WorldGod.Singleton.LoadUI<GameObject>("StoryUI");
            var storyUI = new StoryUI(uiContainer, storyUIObj);
            
            UISystem.System.InitUI(this, playUI);
            UISystem.System.InitUI(this, pauseUI);
            UISystem.System.InitUI(this, windUpUI);
            UISystem.System.InitUI(this, storyUI);
        }
    }
}