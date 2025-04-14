using System;
using UnityEngine;

namespace MyDefense {
    public class PlayerStats : MonoBehaviour {
        #region Fields
        [SerializeField] int initMoney = 400;
        [SerializeField] int initLife = 10;
        static int money = 0;
        static int life = 0;
        #endregion

        //읽기 전용 속성
        #region Property
        public static int Money {
            get { return money; }
        }
        public static int Life {
            get { return life; }
        }
        #endregion

        private void Start() {
            money = initMoney;
            life = initLife;
        }
        public static void GainMoney(int amount) {
            money += amount;
            Debug.Log("Gain Money: " + amount);
            Debug.Log("Current Money: " + money);
        }
        public static void SpendMoney(int amount) {
            money -= amount;
            Debug.Log("Spend Money: " + amount);
            Debug.Log("Current Money: " + money);
        }
        public static void GainLife(int amount) {
            life += amount;
            Debug.Log("Gain Life: " + amount);
            Debug.Log("Current Life: " + life);
        }
        public static void LoseLife(int amount) {
            life -= amount;
            Debug.Log("Lose Life: " + amount);
            Debug.Log("Current Life: " + life);

            if(life <= 0) {
                //게임 오버 처리
                Debug.Log("Game Over");
                //게임 오버 UI 활성화
                //SceneManager.LoadScene("GameOver");
            }
        }
    }

}
