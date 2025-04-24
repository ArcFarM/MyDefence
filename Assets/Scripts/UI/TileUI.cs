using UnityEngine;
using TMPro;
using Unity.VisualScripting;
using UnityEngine.UI;

namespace MyDefence {
    public class TileUI : MonoBehaviour {
        //회전시킬 오브젝트
        [SerializeField] private GameObject offset;
        public Tile selectedTile;

        public Button upButton;
        public TextMeshProUGUI upCost;
        public Image resoureImage;
        public TextMeshProUGUI sellPrice;

        private void Awake() {
            //UI를 숨긴다
            gameObject.SetActive(false);
        }

        private void Start() {
        }


        void ShowThis(Tile t) {
            if(t != null) {
                //Debug.Log("setactive true");
                selectedTile = t;
                transform.position = t.transform.position;
                gameObject.SetActive(true);
                upButton.interactable = true;

                //업그레이드가 불가능한 타워라면 업그레이드 버튼 비활성화
                if (!t.GetTb().IsUnityNull()) {
                    TowerBluePrint tb = t.GetTb();
                    //자원이 부족하면 버튼 비활성화
                    if (!PlayerStats.CheckMoney(tb.upgradeCost)) {
                        upButton.interactable = false;
                        if (!resoureImage.gameObject.activeSelf) {
                            resoureImage.gameObject.SetActive(true);
                        }
                    }
                    //자원이 있어도 업그레이드가 불가능하면 버튼 비활성화
                    if (t.GetTower().TowerLevel >= t.GetTower().MaxLevel) {
                        upCost.text = "Complete";
                        upButton.interactable = false;
                        resoureImage.gameObject.SetActive(false);
                    }
                    else {
                        //업그레이드가 가능한 타워라면 저장된 업그레이드 가격 표시
                        upButton.interactable = true;
                        upCost.text = tb.upgradeCost.ToString();
                        if (!resoureImage.gameObject.activeSelf) {
                            resoureImage.gameObject.SetActive(true);
                        }
                    }
                    //판매가 표시
                    sellPrice.text = t.GetSellValue().ToString();
                }


            }
        }

        void HideThis() {
            //UI를 숨긴다
            gameObject.SetActive(false);
        }

        public void ToggleThis(Tile t) {
            if(gameObject.activeSelf) {
                HideThis();
            }
            else {
                ShowThis(t);
            }
        }

        public void UpgradeTower() {
            selectedTile.UpgradeTower();
        }

        public void SellTower() {
            Debug.Log("SellTower");
            selectedTile.SellTower();
        }
    }

}
