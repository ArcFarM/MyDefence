using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace MyDefence {
    public class GameOver : MonoBehaviour {

        public TextMeshProUGUI waveNumber;

        private void OnEnable() {
            waveNumber.text = PlayerStats.WaveNumber.ToString();
        }

        public void RestartGame() {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        public void GoMainMenu() {
            //
        }
    }

}
