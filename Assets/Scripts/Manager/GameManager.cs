using MyDefence;
using UnityEngine;

namespace MyDefence {
    //게임의 전체 흐름을 관리하는 클래스
    public class GameManager : MonoBehaviour {
        #region Field
        //치트 체크
        [SerializeField] private bool isCheat = false;
        [SerializeField] GameObject GameOverWindow;
        [SerializeField] GameObject PauseWindow;
        [SerializeField] GameObject StageClearWindow;
        [SerializeField] int level = 1;

        public static bool IsGameOver {
            get { return PlayerStats.Life <= 0; }
        }
        
        static GameManager instance;
        public static GameManager Instance {
            get { return instance; }
            }
        #endregion

        private void Awake() {
            if (instance != null) {
                Destroy(gameObject);
                return;
            }
            instance = this;
        }
        
        private void Start() {
            GameOverWindow.SetActive(false);
            PlayerStats.GetCurrentLevel = level;
        }

        private void Update() {
            if (IsGameOver) {
                GameOver();
                return;
            } else {
                GameOverWindow.SetActive(false);
            }
            //Cheating
            if (Input.GetKeyDown(KeyCode.M) && isCheat) {
                ShowMeTheMoney();
            }
            if (Input.GetKeyDown(KeyCode.O) && isCheat) {
                GameOverDebug();
            }
        }

        //Cheating
        //M키를 누르면 10만 골드 지급
        void ShowMeTheMoney() {
            if (isCheat == false)
                return;

            PlayerStats.GainMoney(100000);
        }

        //레벨업 치팅
        void LevelUpCheat() {
            if (isCheat == false)
                return;

            //PlayerStats.LevelUp();
        }

        //게임오버 디버깅
        void GameOverDebug() {
            if (isCheat == false)
                return;
            PlayerStats.LoseLife(10000);
        }

        //public void StageClear()


        void GameOver() {
            //게임오버 처리
            GameOverWindow.SetActive(true);
        }

        public void PauseGame() {
            PauseWindow.SetActive(true);
        }

        private void OnDisable() {
            PlayerPrefs.Save();
        }

        public void LevelClear() {
            //레벨 클리어 처리
            StageClearWindow.SetActive(true);
        }
    }
}
