using System;
using OfficeOpenXml.FormulaParsing.Excel.Functions.Math;
using UnityEngine;

namespace AssetsPackage.Scripts.Utils
{
    public class ARPGTimeCountor
    {
        public ARPGTimeCountor(float duringTime = 1.0f)
        {
            this.DuringTime = duringTime;
        }

        public void Go()
        {
            this.StartTime = Time.time;
        }

        public bool IsCounting
        {
            get
            {
                var currentTime = Time.time; 
                return currentTime > StartTime && currentTime < (StartTime + DuringTime);
            }
        }
        
        public bool IsOver
        {
            get
            {
                var currentTime = Time.time; 
                return currentTime >= (StartTime + DuringTime);
            }
        }

        public float RunTime
        {
            get
            {
                var currentTime = Time.time;
                return Math.Min(currentTime - StartTime, DuringTime);
            }
        }

        public float StartTime;
        public float DuringTime;
    }
}