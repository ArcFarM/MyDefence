using System;
using UnityEngine;


namespace MyDefence {
    //타워 속성(데이터) 정의 직렬화 클래스

    [Serializable]
    public class TowerBluePrint {
        public GameObject towerPrefab;
        public int towerCost;
    }
}
