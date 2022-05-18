using AssetsPackage.Scripts.Game.Compoments.SingletonCompoments;
using AssetsPackage.Scripts.Utils;
using UnityEngine;

namespace AssetsPackage.Scripts.Game.Systems.UpdateSystems
{
    public class InputSignalSystem : ARPGSystemInFrame
    {
        public override void ExecuteOnFixedUpdate()
        {
            base.ExecuteOnFixedUpdate();
        }

        public override void ExecuteOnUpdate()
        {
            base.ExecuteOnUpdate();
            
            var kInput  = KeyBoardInputCompoment.Singlcomp;
            var pSignal = PlayerSignalCompoment.Singlcomp;
            
            {
                kInput.buttonRun.         Tick(Input.GetKey(kInput.keyRun));
                kInput.buttonNormalAttack.Tick(Input.GetKey(kInput.keyNormalAttack));
                kInput.buttonHardAttack.  Tick(Input.GetKey(kInput.keyHardAttack));
                kInput.buttonDodge.       Tick(Input.GetKey(kInput.keyDodge));
            }

            {
                pSignal.targetDForward = (Input.GetKey(kInput.keyUp)    ? 1.0f : 0) - (Input.GetKey(kInput.keyDown) ? 1.0f : 0); 
                pSignal.targetDRight   = (Input.GetKey(kInput.keyRight) ? 1.0f : 0) - (Input.GetKey(kInput.keyLeft) ? 1.0f : 0);

                pSignal.dForward = Mathf.SmoothDamp(pSignal.dForward, pSignal.targetDForward, ref pSignal.dForwardVelocity, 0.15f * Time.fixedDeltaTime);
                pSignal.dRight   = Mathf.SmoothDamp(pSignal.dRight,   pSignal.targetDRight,   ref pSignal.dRightVelocity,   0.15f * Time.fixedDeltaTime);

                Vector2 tempDAxis = SquareToCircle(new Vector2(pSignal.dRight, pSignal.dForward));
                pSignal.circleVector = tempDAxis;
                pSignal.dVector = new Vector3(tempDAxis.x, 0, tempDAxis.y);
                pSignal.dMagnitude = Mathf.Sqrt((tempDAxis.y * tempDAxis.y) + (tempDAxis.x * tempDAxis.x));
            }

            {
                pSignal.dViewUp    = -Input.GetAxis(kInput.keyViewUp)    * kInput.mouseSensityY;
                pSignal.dViewRight =  Input.GetAxis(kInput.keyViewRight) * kInput.mouseSensityX;
            }

            {
                pSignal.RunSignal          = kInput.buttonRun.IsPressing && !kInput.buttonRun.IsDelaying || kInput.buttonRun.IsExtending;
                pSignal.DodgeSignal        = kInput.buttonDodge.OnPressed;
                pSignal.NormalAttackSignal = kInput.buttonNormalAttack.OnPressed || kInput.buttonNormalAttack.IsExtending && kInput.buttonNormalAttack.OnPressed;
                pSignal.HardAttackSignal   = kInput.buttonHardAttack.OnPressed || kInput.buttonHardAttack.IsExtending && kInput.buttonHardAttack.OnPressed;
            }
        }

        private Vector2 SquareToCircle(Vector2 input)
        {
            Vector2 output = Vector2.zero;
            output.x = input.x * Mathf.Sqrt(1 - (input.y * input.y) / 2.0f);
            output.y = input.y * Mathf.Sqrt(1 - (input.x * input.x) / 2.0f);

            return output;
        }
    }
}