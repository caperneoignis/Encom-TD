<<<<<<< HEAD
﻿using System;
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
=======
﻿using UnityEngine;
using System.Collections;

public class MainGame : MonoBehaviour {
	public float nextTime_= 0.0f;
	public float timeBetweenBalloons_=1.0f;
	public GameObject balloonPrefab_;
	public int numBalloons_ = 0;
	public int balloonsInWave_ = 5;
	public static int totalScore_ = 0;
	public static int lives_ = 5;
	public int numberOfWaves_ = 1;
	public bool needToBeCalled_= true;
	// Use this for initialization
	void Start () {
		totalScore_ = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if (lives_ > 0) {
			if (nextTime_ < Time.time) {
				if(numBalloons_ < balloonsInWave_)
				{
					CreateBalloon();
					numBalloons_++;
				}
				else
				{	
					if(needToBeCalled_)
					{
						StartCoroutine(DelayWave());
						needToBeCalled_= false;
					}
				}
				nextTime_ = Time.time + timeBetweenBalloons_;	
			}
		}
	}

	public void CreateBalloon()
	{
		Instantiate (balloonPrefab_);
	}

	public void OnGUI()
	{
		GUI.color = Color.white;
		GUI.Label(new Rect(10, 10, 120, 20), "Lives: " + lives_.ToString());
		GUI.Label(new Rect(10, 30, 60, 20), "Score: " + totalScore_.ToString());
	}
	public IEnumerator DelayWave()
	{
		yield return new WaitForSeconds(8f);
		makeNextWave ();
	}

	public void makeNextWave()
	{
		if (numberOfWaves_ % 5 == 0) 
		{
			timeBetweenBalloons_-=.1f;
		}
		balloonsInWave_ += 3;
		numBalloons_ = 0;
		needToBeCalled_ = true;
	}

>>>>>>> 63821ce59e773a75b21d8639e4b7d2ade7850df0
}
