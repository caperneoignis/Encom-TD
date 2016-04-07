using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using UnityEngine;






namespace TowerDefenseGame
{
    [TestFixture]
    public class TestSomethign
    {
        //static void Main(string[] args)
        //{
        //}


        [Test]
        public void AutoaimInitialize()
        {
            Autoaim testAuto = new Autoaim();
            //Vector3 position1 = new Vector3(0, 0, 0);
            //testAuto.target_.position = position1;
            Assert.IsTrue(testAuto.initialized_);

        }
        [Test]
        public void AutoaimPositions()
        {
            Autoaim testAuto = new Autoaim();
            Vector3 position1 = new Vector3(0f, 0f, 0f);
            Vector3 position2 = new Vector3(2f, 0f, 0f);
            testAuto.SetPositions(position1, position2);
            Assert.True(testAuto.targetPosition1_ == position1 && testAuto.targetPosition2_ == position2);
        }
        [Test]
        public void CalculateTargetVelocity()
        {
            Autoaim testAuto = new Autoaim();
            Vector3 returnVelocity;
            Vector3 trueVelocity = new Vector3(2f, 0f, 0f);
            Vector3 position1 = new Vector3(0f, 0f, 0f);
            Vector3 position2 = new Vector3(2f, 0f, 0f);
            testAuto.SetPositions(position1, position2);
            returnVelocity = testAuto.CalculateTargetVelocity();
            Assert.True(returnVelocity == trueVelocity);


        }
        [Test]
        public void CalculateBulletVelocity()
        {
            float force = 1000f;
            float answerVelocity = 20.0f;
            Autoaim testAuto = new Autoaim();
            testAuto.SetBulletForce(force);
            testAuto.CalculateBulletVelocity();
            Assert.True(testAuto.bulletVelocity_ == answerVelocity);
        }


        [Test]
        public void CalculateDistance()
        {
            Autoaim testAuto = new Autoaim();
            Vector3 targetPosition = new Vector3(0f, 0f, 0f);
            Vector3 turretPosition = new Vector3(2f, 2f, 0f);
            float distance;
            float answerDistanceman = (float)Math.Sqrt(Math.Pow(2, 2) + Math.Pow(2, 2));
            double answerDistance = (double)Vector3.Distance(targetPosition, turretPosition);
            testAuto.SetPositions(targetPosition, targetPosition);
            testAuto.SetTurretPosition(turretPosition);
            distance = testAuto.CalculateDistance();
            Assert.True(distance == answerDistanceman);


        }

        [Test]
        public void CalculateTargetSpeed()
        {
            Autoaim testAuto = new Autoaim();
            Vector3 targetPosition = new Vector3(0f, 0f, 0f);
            Vector3 turretPosition = new Vector3(2f, 2f, 0f);
            testAuto.SetPositions(targetPosition, targetPosition);
            testAuto.SetTurretPosition(turretPosition);
            float test = (float)Math.Sqrt(Math.Pow(2, 2) + Math.Pow(2, 2));
            Assert.True(testAuto.CalculateTargetSpeed() == test);
        }

        [Test]
        public void CalculatePositionToShoot()
        {
            Autoaim testAuto = new Autoaim();
            Vector3 targetPosition1 = new Vector3(0f, 0f, 0f);
            Vector3 targetPosition2 = new Vector3(2f, 2f, 0f);
            Vector3 turretPosition = new Vector3(3f, 3f, 0f);
            testAuto.SetPositions(targetPosition1, targetPosition2);
            testAuto.SetTurretPosition(turretPosition);
            testAuto.SetBulletForce(1000.0f);

        }

        [Test]
        public void FirstWave()
        {
            MainGame testMain = new MainGame();
            Assert.True(testMain.balloonsInWave_ == 5 && testMain.timeBetweenBalloons_ == 1.0f);
        
        }

        [Test]
        public void Wave5()
        {
            MainGame testMain = new MainGame();
            for (int i = 0; i < 5; i++)
            {
                testMain.makeNextWave();
            }
            Assert.True(testMain.balloonsInWave_ == 20 && testMain.timeBetweenBalloons_ == .9f);
        }

        [Test]
        public void instancesOfMainGame()
        {
            MainGame testMain = new MainGame();
            MainGame copy = new MainGame();
            Assert.IsNotNull(copy);

        }
    }
    class Program
    {
        static int Main()


        { return 0; }

    }
}
