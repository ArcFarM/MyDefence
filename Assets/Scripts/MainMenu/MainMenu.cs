using UnityEngine;
using UnityEngine.SceneManagement;

namespace MyDefence {
    public class MainMenu : MonoBehaviour {
        public void PlayGame() {
            SceneManager.LoadScene("PlayScene");
        }
        public void QuitGame() {
            Application.Quit();
            Debug.Log("QUIT");
        }
    }
}
