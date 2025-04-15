using System.Collections;
using UnityEngine;
using TMPro;

//적 스포너

namespace MyDefence {
    public class WaveManager : MonoBehaviour {

        //소환할 적
        public GameObject enemy;
        //타이머
        public float waveTimer = 5f;
        float countdown = 0f;
        //웨이브 카운트
        int waveCount = 0;
        public TextMeshProUGUI waveCountText;
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start() {
            //Instantiate(enemy, Get_Waypoints.waypoints[0].position, Quaternion.identity);
        }

        // Update is called once per frame
        void Update() {
            if(GameManager.IsGameOver) {
                return;
            }
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
                Instantiate(enemy, Get_Waypoints.waypoints[0].position, Quaternion.identity);
                yield return new WaitForSeconds(0.3f);
            }
        }

    }
}

