using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace MyDefence {
    public class Pause : MonoBehaviour {

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
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        public void GoMainMenu() {
            //
        }

        void Toggle() {
            gameObject.SetActive(!gameObject.activeSelf);
        }
    }

}
