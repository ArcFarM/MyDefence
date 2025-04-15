using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace MyDefence {
    public class Pause : MonoBehaviour {

        private void OnEnable() {
            Time.timeScale = 0f;
        }

        public void Resume() {
            gameObject.SetActive(false);
        }

        public void RestartGame() {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            Time.timeScale = 1f;
        }

        public void GoMainMenu() {
            //
        }
    }

}
