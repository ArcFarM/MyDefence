using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace MyDefence {
    public class Pause : MonoBehaviour {

        public FadeInOut fadeOutPanel;
        bool restartFlag = true;

        private void OnEnable() {
            Time.timeScale = 0f;
        }

        private void OnDisable() {
            Time.timeScale = 1f;
        }
        

        public void Resume() {
            Toggle(); 
        }

        public void RestartGame() {
            restartFlag = true;
            StartCoroutine(FadeOut());
        }

        public void GoMainMenu() {
            restartFlag = false;
            StartCoroutine(FadeOut());
        }

        void Toggle() {
            gameObject.SetActive(!gameObject.activeSelf);
        }

        IEnumerator FadeOut() {
            //페이드 아웃 애니메이션 시작
            if(restartFlag) yield return StartCoroutine(fadeOutPanel.Do_FadeOut(SceneManager.GetActiveScene().name));
            else yield return StartCoroutine(fadeOutPanel.Do_FadeOut("MainMenu"));
        }
    }

}
