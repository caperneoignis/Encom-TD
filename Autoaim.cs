using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace TowerDefenseGame
{
    public class Autoaim
    {
        const float PHYSICS_CONST = .02f;
        public Vector3 targetPosition1_ = new Vector3(0f, 0f, 0f);
        public Vector3 targetPosition2_ = new Vector3(2f, 0f, 0f);
        public Vector3 turretPosition_;
        public float bulletVelocity_;
        public float bulletForce_;
        public bool initialized_;
        public Autoaim()
        {
            initialized_ = true;
            bulletVelocity_ = 0;
            bulletForce_ = 0;
            turretPosition_ = new Vector3(0, 0, 0);
        }

        public void SetPositions(Vector3 position1, Vector3 position2)
        {
            targetPosition1_ = position1;
            targetPosition2_ = position2;
        }

        public void SetTurretPosition(Vector3 position)
        {
            turretPosition_ = position;
        }

        public void SetBulletForce(float force)
        {
            bulletForce_ = force;
        }

        public Vector3 CalculateTargetVelocity()
        {
            Vector3 Velocity;
            Velocity = targetPosition2_ - targetPosition1_;
            return Velocity;
        }

        public void CalculateBulletVelocity()
        {
            bulletVelocity_ = bulletForce_ * PHYSICS_CONST;
        }

        public float CalculateDistance()
        {
            float distance = 0f;
            distance = Vector3.Distance(targetPosition1_, turretPosition_);
            return distance;
        }
    }
}
