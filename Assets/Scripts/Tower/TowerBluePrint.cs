using System;
using UnityEngine;


namespace MyDefence {
    //타워 속성(데이터) 정의 직렬화 클래스

    [Serializable]
    public class TowerBluePrint {
        public GameObject towerPrefab;
        public int towerCost;

        public GameObject upgradePrefab;
        public int upgradeCost;
        public int towerLevel;

        public float GetSellValue() {
            float result = towerCost / 2;
            for(int i = 1; i < towerLevel; i++) {
                result += upgradeCost / 2;
            }
            return result;
        }

        int maxLevel = 2;
        public bool IsMaxLevel() {
            if (towerLevel >= maxLevel) {
                return true;
            }
            return false;
        }
    }
}
