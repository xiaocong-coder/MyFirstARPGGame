using AssetsPackage.Scripts.Game.BackState_Moduels;
using AssetsPackage.Scripts.Game.Compoments.SingletonCompoments;
using AssetsPackage.Scripts.Game.CustomClasses.LevelStates;
using AssetsPackage.Scripts.Tool;
using AssetsPackage.Scripts.Utils;
using UnityEngine;
using UnityEngine.UI;

namespace AssetsPackage.Scripts.Game.CustomClasses.UI
{
    public class PauseUI : ARPGUI
    {
        public PauseUI(Transform uiContainer, GameObject uiObj) : base(uiContainer, uiObj)
        {
            var trans = uiObj.transform;
            
            this.BackToGameButton = FindGameObject.GetTransformInChildByName("BackToGameButton", trans).GetComponent<Button>();
            this.BackToGameLevelSelectButton = FindGameObject.GetTransformInChildByName("BackToLevelSelectButton", trans).GetComponent<Button>();
            this.RetryLevelButton = FindGameObject.GetTransformInChildByName("RetryLevelButton", trans).GetComponent<Button>();
            
            this.BackToGameButton.onClick.AddListener(BackToPlay);
            this.BackToGameLevelSelectButton.onClick.AddListener(BackToLevelSelect);
            this.RetryLevelButton.onClick.AddListener(RetryGame);
        }

        public Button BackToGameButton;
        public Button BackToGameLevelSelectButton;
        public Button RetryLevelButton;

        private void BackToPlay()
        {
            var timeComp = GameTimeVelocityComponent.Singlcomp;
            
            timeComp.TimeVelocity = timeComp.LateTimeVelocity;
            timeComp.LateTimeVelocity = timeComp.TimeVelocity;
                        
            var allAnimators = AllEngineItemCompoment.Singlcomp.AllAnimators;
            foreach (var animator in allAnimators)
            {
                animator.speed = 1;
            }

            var allRigidBody = AllEngineItemCompoment.Singlcomp.AllRigidBodys;
            foreach (var rigidbody in allRigidBody)
            {
                rigidbody.constraints = RigidbodyConstraints.FreezeRotation;
            }

            var nextState = WorldGod.Singleton.CurrentWorld.AllLevelStates[typeof(LPlayState)];
            ARPGState.ChangeState(ref WorldGod.Singleton.CurrentWorld.CurrentState, nextState);   
        }
        private void BackToLevelSelect()
        {
            WorldGod.Singleton.EnterMain();
        }

        private void RetryGame()
        {
            WorldGod.Singleton.EnterLevel(WorldGod.Singleton.CurrentWorld.name);
        }
    }
}