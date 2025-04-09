using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Sample {
    public class MoneyTest : MonoBehaviour {

        #region fields
        public static int gold;
        public int init_gold;

        public TextMeshProUGUI goldText;
        public Button[] buttons;
        public int[] button_prices;

        #endregion


        void Start() {
            gold = init_gold;
        }
        void Update() {
            goldText.text = gold.ToString() + " $"; // UI에 현재 금액 표시

            for(int i = 0; i < buttons.Length; i++) {
                if (button_prices[i] <= gold) {
                    buttons[i].GetComponent<Button>().GetComponent<Image>().color = Color.white; // 버튼 색상 변경
                    buttons[i].interactable = true; // 버튼 활성화
                } else {
                    buttons[i].GetComponent<Button>().GetComponent<Image>().color = Color.red; // 버튼 색상 변경
                    buttons[i].interactable = false; // 버튼 비활성화
                }
            }
        }



        public void AddGold(int amount) {
            gold += amount;
            Debug.Log("Gold added: " + amount);
            Debug.Log("Current Gold: " + gold);
        }

        public void SpendGold(int amount) {
            if (gold >= amount) {
                gold -= amount;
                Debug.Log("Gold spent: " + amount);
                Debug.Log("Current Gold: " + gold);
            }
            else {
                if(this.GetComponent<Button>() != null) {
                    this.GetComponent<Button>().GetComponent<Image>().color = Color.red; // 버튼 색상 변경
                    this.GetComponent<Button>().interactable = false;
                }
                Debug.Log("Not enough gold to spend: " + amount);
            }
        }

        public bool CheckGold(int amount) {
            if(amount <= gold) {
                return true;
            }
            else {
                return false;
            }
        }
    }
}

/*
 시작 시 소지금 지급
 돈 현황을 파악할 수 있또록 UI를 표시
돈 지급, 돈 소모 등을 할 수 있는 버튼 구현
+ 돈이 모자라다면 구매를 할 수 없다는 것도 보여야 함
 */