using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace TowerDefenseGame
{
    public class MainGame
    {
        public float nextTime_ = 0.0f;
        public float timeBetweenBalloons_ = 1.0f;
        public GameObject balloonPrefab_;
        public int numBalloons_ = 0;
        public int balloonsInWave_ = 5;
        public static int totalScore_ = 0;
        public static int lives_ = 5;
        public int numberOfWaves_ = 1;
        public bool needToBeCalled_ = true;
        //singelton
        private static MainGame instance = null;
        public static MainGame Instance { get { return instance; } }
        // Use this for initialization
        void Start()
        {
            totalScore_ = 0;
        }

        // Update is called once per frame

        public void makeNextWave()
        {
            if (numberOfWaves_ % 5 == 0)
            {
                timeBetweenBalloons_ -= .1f;
            }
            balloonsInWave_ += 3;
            numBalloons_ = 0;
            needToBeCalled_ = true;
            numberOfWaves_++;
        }

    }
}
