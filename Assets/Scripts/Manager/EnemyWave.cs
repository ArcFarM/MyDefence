using System;
using UnityEngine;

namespace MyDefence {

    [Serializable]
    public class EnemyWave {
        public GameObject enemy;
        public int count;
        public float spawnInterval;
    }
}