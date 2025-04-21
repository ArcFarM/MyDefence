using System.Collections;
using UnityEngine;
using TMPro;

//적 스포너

namespace MyDefence {
    public class WaveManager : MonoBehaviour {

        //소환할 적 구성
        public EnemyWave[] enemyWaves;
        
        //타이머
        public float waveTimer = 5f;
        float countdown = 0f;
        public float spawnTimer = 0.3f;

        //적 개체수
        public static float enemyCount = 0f;
        //웨이브 카운트
        int waveCount = 0;
        public TextMeshProUGUI waveCountText;
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start() {
            //Instantiate(enemy, Get_Waypoints.waypoints[0].position, Quaternion.identity);
        }

        // Update is called once per frame
        void Update() {
            //게임오버 상태 혹은 적이 없을 때만 적 스폰
            if (GameManager.IsGameOver) return;
            if (enemyCount > 0) return;

            countdown += Time.deltaTime;
            waveCountText.text = ((int)(waveTimer - countdown)).ToString();
            if (countdown >= waveTimer) {
                waveCount++;
                PlayerStats.WaveNumber++;
                countdown = 0f;
                StartCoroutine(Spawn_Enemy());
            }
        }

        IEnumerator Spawn_Enemy() {
            for(int i = 0; i < waveCount; i++) {
                Instantiate(enemyWaves[0].enemy, Get_Waypoints.waypoints[0].position, Quaternion.identity);
                yield return new WaitForSeconds(0.3f);
            }
        }

    }
}

