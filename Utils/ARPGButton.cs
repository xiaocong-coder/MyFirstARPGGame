namespace AssetsPackage.Scripts.Utils
{
    public class ARPGButton
    {
        public bool IsPressing = false;
        public bool OnPressed = false;
        public bool OnRelease = false;
        public bool IsExtending = false;
        public bool IsDelaying = false;

        private bool lastState = false;
        private bool currentState = false;

        private ARPGTimer extendTimer = new ARPGTimer();
        private ARPGTimer delayTimer  = new ARPGTimer();
        private float extendingDuration = 0.5f;
        private float delayingDuration  = 0.15f;
    
        public ARPGButton(float extendingDuration = 0.5f, float delayingDuration = 0.15f, float timeDuration = 1.0f){
            this.extendingDuration = extendingDuration;
            this.delayingDuration = delayingDuration;
        }
    
        public void Tick(bool input)
        {
            extendTimer.Tick();
            delayTimer.Tick();

            currentState = input;
            IsPressing = currentState;

            OnRelease = false;
            OnPressed = false;
            IsExtending = false;
            IsDelaying = false;

            if(currentState != lastState)
            {
                if(currentState == true)
                {
                    OnPressed = true;
                    StartTimer(delayTimer, delayingDuration);
                }
                else
                {
                    OnRelease = true;
                    StartTimer(extendTimer, extendingDuration);
                }
            }
            lastState = currentState;

            if (delayTimer.state == ARPGTimer.STATE.RUN)
            {
                IsDelaying = true;
            }
            
            if (extendTimer.state == ARPGTimer.STATE.RUN)
            {
                IsExtending = true;
            }
        }

        void StartTimer(ARPGTimer timer, float duration)
        {
            timer.duration = duration;
            timer.Go();
        }
    }
}