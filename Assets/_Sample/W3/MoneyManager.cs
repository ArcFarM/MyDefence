using TMPro;
using UnityEngine;

namespace Sample {
    public class MoneyManager : MonoBehaviour {

        public GameObject moneyUI; // UI 오브젝트

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start() {

        }

        // Update is called once per frame
        void Update() {
            moneyUI.GetComponent<TextMeshProUGUI>().text = (MoneyTest.gold.ToString() + " $"); 
        }
    }

}
