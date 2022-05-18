using UnityEngine;

namespace AssetsPackage.Scripts.Utils
{
    public class ARPGTimer
    {
        public enum STATE
        {
            IDLE,
            RUN,
            FINISHED
        }

        public STATE state = STATE.IDLE;
        public float duration = 1.0f;
        private float elapsedTime = 0;

        public ARPGTimer(float duration = 1)
        {
            this.duration = duration;
        }

        public void Tick()
        {
            if (state == STATE.IDLE)
            {
                ;
            }
            else if (state == STATE.RUN)
            {
                elapsedTime += Time.deltaTime;
                if (elapsedTime >= duration)
                    state = STATE.FINISHED;
            }
            else if (state == STATE.FINISHED)
            {
                ;
            }
        }

        public void Go()
        {
            elapsedTime = 0;
            state = STATE.RUN;
        }

        public void Reset()
        {
            elapsedTime = 0;
            state = STATE.IDLE;
        }
    }
}