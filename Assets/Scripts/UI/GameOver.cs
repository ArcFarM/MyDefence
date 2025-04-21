using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace MyDefence {
    public class GameOver : MonoBehaviour {

        public TextMeshProUGUI waveNumber;
        public FadeInOut fadeOutPanel;

        bool restartFlag = true;

        private void OnEnable() {
            waveNumber.text = PlayerStats.WaveNumber.ToString();
        }

        public void RestartGame() {
            restartFlag = true;
            StartCoroutine(FadeOut());
        }

        public void GoMainMenu() {
            restartFlag = false;
            StartCoroutine(FadeOut());
        }

        IEnumerator FadeOut() {
            //페이드 아웃 애니메이션 시작
            if (restartFlag) {
              yield return StartCoroutine(fadeOutPanel.Do_FadeOut(SceneManager.GetActiveScene().name));
            }
            else yield return StartCoroutine(fadeOutPanel.Do_FadeOut("MainMenu"));
        }
    }

}
