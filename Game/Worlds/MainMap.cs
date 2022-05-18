using System;
using System.Collections.Generic;
using AssetsPackage.Scripts.Game.BackState_Moduels;
using AssetsPackage.Scripts.Game.CustomClasses.MainStates;
using AssetsPackage.Scripts.Game.CustomClasses.UI;
using AssetsPackage.Scripts.Game.Systems.InitizeSystems;
using AssetsPackage.Scripts.Tool;
using AssetsPackage.Scripts.Utils;
using UnityEngine;

namespace AssetsPackage.Scripts.Game.Worlds
{
    public class MainMap : ARPGWorld
    {
        public override void Awake()
        {
            base.Awake();
            
            InitEntitiesList();
            InitSinglCompEntity();
            InitStateMachine();
            InitUIContainer();
            InitAllUI();
        }

        private void InitStateMachine()
        {
            this.AllLevelStates = new Dictionary<Type, ARPGState>()
            {
                {typeof(MIdleState),    new MIdleState()},
                {typeof(MStartupState), new MStartupState()}
            };
            this.CurrentState = ARPGState.DefaultState;
            ARPGState.ChangeState(ref this.CurrentState, this.AllLevelStates[typeof(MIdleState)]);
        }
        
        private void InitEntitiesList()
        {
            this.EntitiesList = new Dictionary<int, ARPGEntity>();
        }
        
        private void InitSinglCompEntity()
        {
            var entitiesGroupID = ARPGEntitiesGroupID.SingCompManager;
            ARPGEntity SingCompManagerEntity = new ARPGEntity(null);
            var compoments = ARPGCompomentsGenerator.GetMainSingCompManagerCompoment();
            SingCompManagerEntity.SetCompoments(compoments);
            
            this.EntitiesList.Add(SingCompManagerEntity.EntityID, SingCompManagerEntity);
            this.EntitiesGroup.AddEntityToGroup(entitiesGroupID, SingCompManagerEntity);
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

        private void InitAllUI()
        {
            var uiContainer = FindGameObject.GetTransformInChildByName("UIContainer", this.transform);

            var dialogueUIObj = WorldGod.Singleton.LoadUI<GameObject>("DialogueUI");
            var dialogueUI = new DialogueUI(uiContainer, dialogueUIObj); 
                
            var startupUIObj = WorldGod.Singleton.LoadUI<GameObject>("StartupUI");
            var startupUI = new StartupUI(uiContainer, startupUIObj);
            
            var gamelevelSelectUIObj = WorldGod.Singleton.LoadUI<GameObject>("GamelevelSelectUI");
            var gamelevelSelectUI = new GameLevelSelectUI(uiContainer, gamelevelSelectUIObj);

            var optionUIObj = WorldGod.Singleton.LoadUI<GameObject>("OptionUI");
            var optionUI = new OptionUI(uiContainer, optionUIObj);
            
            UISystem.System.InitUI(this, dialogueUI);
            UISystem.System.InitUI(this, startupUI);
            UISystem.System.InitUI(this, gamelevelSelectUI);
            UISystem.System.InitUI(this, optionUI);
            
            UISystem.System.ShowUIAndHideOther(this, typeof(StartupUI));
        }
    }
}