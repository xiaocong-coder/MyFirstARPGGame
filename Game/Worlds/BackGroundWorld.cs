using System;
using System.Collections.Generic;
using AssetsPackage.Scripts.Game.BackState_Moduels;
using AssetsPackage.Scripts.Game.CustomClasses.BackGroundState;
using AssetsPackage.Scripts.Game.CustomClasses.UI;
using AssetsPackage.Scripts.Game.Systems.InitizeSystems;
using AssetsPackage.Scripts.Tool;
using AssetsPackage.Scripts.Utils;
using UnityEngine;

namespace AssetsPackage.Scripts.Game.Worlds
{
    public class BackGroundWorld : ARPGWorld
    {
        public override void Awake()
        {
            base.Awake();
            
            InitEntitiesList();
            InitStateMachine();
            InitUIContainer();
            InitUI();
        }

        private void Start()
        {
            
        }

        private void InitEntitiesList()
        {
            this.EntitiesList = new Dictionary<int, ARPGEntity>();
        }
        
        private void InitStateMachine()
        {
            this.AllLevelStates = new Dictionary<Type, ARPGState>
            {
                { typeof(BGIdelState),      new BGIdelState() },
                { typeof(BGLoadingState),   new BGLoadingState() }
            };
            this.CurrentState = ARPGState.DefaultState;
            ARPGState.ChangeState(ref this.CurrentState, AllLevelStates[typeof(BGIdelState)]);
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
            
            var loadingUIObj = WorldGod.Singleton.LoadUI<GameObject>("LoadingUI");
            var loadingUI = new LoadingUI(uiContainer, loadingUIObj);
            
            UISystem.System.InitUI(this, loadingUI);
            UISystem.System.CloseUI(this, typeof(LoadingUI));
        }
    }
}