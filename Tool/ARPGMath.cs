using UnityEngine;

namespace AssetsPackage.Scripts.Tool
{
    public static class ARPGMath
    {
        public static bool CheckInDistance(Transform target, Transform self, float compareDistance)
        {
            var vector = (target.position - self.position);
            var distance = vector.magnitude;
            if (distance < compareDistance)
            {
                return true;
            }

            return false;
        }

        public static bool CheckInAngle(Transform target, Transform self, float compareAngle)
        {
            var targetForward = (target.position - self.position).normalized;
            var angle = Vector3.Angle(self.forward.normalized, targetForward);
                
            if (angle < compareAngle / 2)
            {
                return true;
            }

            return false;
        }

        public static bool CheckInArea(Transform target, Transform self, float attackDistance, float checkAngle)
        {
            if (CheckInDistance(target, self, attackDistance))
            {
                if (CheckInAngle(target, self, checkAngle))
                {
                    return true;
                }
            }

            return false;
        }
        
        public static Vector3 CorrectVectorNormalize(Vector3 vector)
        {
            return new Vector3(vector.x, 0, vector.z).normalized;
        }
    }
}