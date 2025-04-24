using System;
using UnityEngine;

namespace MyDefence {

    [Serializable]
    public class EnemyWave {
        public int size;
        public GameObject[] enemy;
        public int[] count;
        public float[] spawnInterval;
    }
}