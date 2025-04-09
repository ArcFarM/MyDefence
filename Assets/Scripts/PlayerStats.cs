using System;
using UnityEngine;

namespace MyDefense {
    public class PlayerStats : MonoBehaviour {
        #region Fields
        static int money = 0;
        [SerializeField] int initMoney = 400;
        #endregion

        //읽기 전용 속성
        #region Property
        public static int Money {
            get { return money; }
        }
        #endregion

        private void Start() {
            money = initMoney;
        }
        public static void GainMoney(int amount) {
            money += amount;
        }
        public static void SpendMoney(int amount) {
            money -= amount;
        }

        public bool CheckMoney(int amount) {
            if (amount >= money) return true;
            else return false;
        }
    }

}
