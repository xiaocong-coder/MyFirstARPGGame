using System.Text;
using AssetsPackage._2._Scripts.Game.Compoments.SingletonCompoments;
using AssetsPackage.Scripts.Game.BackState_Moduels;
using AssetsPackage.Scripts.Game.Compoments.NormalCompoments;
using AssetsPackage.Scripts.Game.CustomClasses.LevelStates;
using AssetsPackage.Scripts.Game.CustomClasses.UI;
using AssetsPackage.Scripts.Utils;
using UnityEngine;

namespace AssetsPackage.Scripts.Game.Systems.UpdateSystems
{
    public class StoryPlaySystem : ARPGSystemInFrame
    {
        public override void ExecuteOnUpdate()
        {
            base.ExecuteOnUpdate();
            
            var entities = WorldGod.Singleton.CurrentWorld.EntitiesGroup[ARPGEntitiesGroupID.UIContainerGroupID];
            entities.ForEach(entity =>
            {
                var storyCacheComp = StoryCacheCompoment.Singlcomp;
                var uiContainComp  = GetCompomentData<UIContainCompoment>(entity);
                
                storyCacheComp.DelayTimer.Tick();

                var storyUI = uiContainComp.UIContainer[typeof(StoryUI)] as StoryUI;

                var levelName = WorldGod.Singleton.CurrentWorld.name;
                var storyText = ARPGStory.GameLevelStory[levelName];

                if (storyCacheComp.RefreshTextTimerCounter.IsOver)
                {
                    if (storyCacheComp.Index >= storyText.Length && storyCacheComp.DelayTimer.state == ARPGTimer.STATE.IDLE)
                    {
                        storyCacheComp.DelayTimer.Go();
                    }
                    else if(storyCacheComp.Index < storyText.Length)
                    {
                        var index = storyCacheComp.Index;
                        storyCacheComp.StoryCacheText.Append(storyText[index].ToString());
                        storyCacheComp.Index++;

                        storyUI.StoryText.text = storyCacheComp.StoryCacheText.ToString();
                    
                        storyCacheComp.RefreshTextTimerCounter.Go();   
                    }
                }
            });
        }

        public override void ExecuteOnLateUpdate()
        {
            base.ExecuteOnLateUpdate();
            
            var storyCacheComp = StoryCacheCompoment.Singlcomp;
            if (storyCacheComp.DelayTimer.state == ARPGTimer.STATE.FINISHED)
            {
                var nextState = WorldGod.Singleton.CurrentWorld.AllLevelStates[typeof(LPlayState)];
                ARPGState.ChangeState(ref WorldGod.Singleton.CurrentWorld.CurrentState, nextState);   
            }
        }
    }
}