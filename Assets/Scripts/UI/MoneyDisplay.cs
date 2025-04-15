using UnityEngine;
using TMPro;
using UnityEngine.UI;

namespace MyDefence {
    public class MoneyDisplay : MonoBehaviour {
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        public TextMeshProUGUI moneyText;
        void Start() {

        }

        // Update is called once per frame
        void Update() {
            moneyText.text = PlayerStats.Money.ToString();
        }
    }
}

