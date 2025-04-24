using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
//적 스포너

namespace MyDefence {
    public class WaveManager : MonoBehaviour {

        //소환할 적 구성
        public EnemyWave[] enemyWaves;
        //적 개체수
        public static float enemyCount = 0f;
        //웨이브 정보 표시
        public int waveCount = 0;
        public TextMeshProUGUI waveInfoText;
        //웨이브 시작 버튼
        public GameObject startButton;
        //일시정지 버튼으로 교체용
        Sprite startImage;
        public Sprite pauseImage;
        public bool isStarted = false;

        private void Start() {
            startImage = startButton.GetComponent<Button>().image.sprite;
        }

        private void Update() {
            if (enemyCount > 0) return;

            //웨이브가 끝나면 다시 시작버튼으로 이미지 변경
            if (isStarted) {
                startButton.GetComponent<Button>().image.sprite = startImage;
                isStarted = false;
                //웨이브 정보 표시
                if(waveCount < enemyWaves.Length)
                waveInfoText.text = $"{waveCount + 1} / {enemyWaves.Length}";
            }

            if(waveCount >= enemyWaves.Length) {
                //웨이브가 끝나면 게임 클리어
                GameManager.Instance.LevelClear();
                return;
            }
        }

        public void StartWave() {
            if (isStarted || enemyCount > 0) {
                //웨이브가 시작한 상태에서 누르면 일시정지를 실행
                GameManager.Instance.PauseGame();
                return;
            }
            isStarted = true;
            //시작 버튼 이미지를 일시정지 이미지로 교체
            startButton.GetComponent<Button>().image.sprite = pauseImage;
            StartCoroutine(Spawn_Enemy(waveCount));
            if(waveCount < enemyWaves.Length) {  
                waveCount++;
            }
        }
        //웨이브 시작
        public IEnumerator Spawn_Enemy(int wave) {
            if(wave >= enemyWaves.Length) yield break;
            EnemyWave ew = enemyWaves[wave];
            ew.size = ew.enemy.Length;
            for (int j = 0; j < ew.size; j++) {
                enemyCount += ew.count[j]; //적 수 증가 처리
                //i번째 웨이브의 j번째 구성으로 웨이브 생성
                for (int k = 0; k < ew.count[j]; k++) {
                    //적 소환
                    Instantiate(ew.enemy[j], Get_Waypoints.waypoints[0].position, Quaternion.identity);
                    yield return new WaitForSeconds(ew.spawnInterval[j]);
                }
            }
        }

    }
}

