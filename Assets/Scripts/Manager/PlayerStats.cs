using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace MyDefence {
    public class PlayerStats : MonoBehaviour {
        #region Fields
        [SerializeField] int initMoney = 400;
        [SerializeField] int initLife = 10;
        static int money = 0;
        static int life = 0;
        static int waveNumber = 0;
        //PlayerPrefs : 로컬 경로에 K_V 쌍으로 저장
        static int bestLevel = 1;
        static int currLevel = 0; //현재 레벨
        #endregion

        //읽기 전용 속성
        #region Property
        public static int Money {
            get { return money; }
        }
        public static int Life {
            get { return life; }
        }
        public static int WaveNumber {
            get { return waveNumber; }
            set { waveNumber = value; }
        }

        public static bool CheckMoney(float amount) {
            if (money >= amount) return true;
            return false;
        }

        public static int GetBestLevel {
            get { return bestLevel; }
        }

        public static int GetCurrentLevel {
            get { return currLevel; }
            set { currLevel = value; }
        }
        #endregion

        private void Awake() {
            bestLevel = Math.Max(PlayerPrefs.GetInt("PlayableLevel", 1), 1);
            money = initMoney;
            life = initLife;
            waveNumber = 0;
        }

        public static void GainMoney(int amount) {
            money += amount;
            //Debug.Log("Gain Money: " + amount);
            //Debug.Log("Current Money: " + money);
        }
        public static void SpendMoney(int amount) {
            money -= amount;
            //Debug.Log("Spend Money: " + amount);
            //Debug.Log("Current Money: " + money);
        }
        
        public static void GainLife(int amount) {
            life += amount;
            //Debug.Log("Gain Life: " + amount);
            //Debug.Log("Current Life: " + life);
        }
        public static void LoseLife(int amount) {
            life -= amount;
           // Debug.Log("Lose Life: " + amount);
           // Debug.Log("Current Life: " + life);
        }
    }

}
