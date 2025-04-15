using UnityEngine;
using TMPro;
using UnityEngine.UI;

namespace MyDefence {
    public class LifeDisplay : MonoBehaviour {
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        public TextMeshProUGUI displayText;
        void Start() {

        }

        // Update is called once per frame
        void Update() {
            displayText.text = PlayerStats.Life.ToString();
        }
    }
}

