using UnityEngine;
using TMPro;

namespace MyDefence {
    public class TileUI : MonoBehaviour {
        //회전시킬 오브젝트
        [SerializeField] private GameObject offset;
        public Tile selectedTile;

        private void Awake() {
            //UI를 숨긴다
            gameObject.SetActive(false);
        }

        public TextMeshProUGUI upCost;

        public void ShowThis(Tile t) {
            if(t != null) {
                Debug.Log("setactive true");
                selectedTile = t;
                transform.position = t.transform.position;
                gameObject.SetActive(true);
            }
        }

        public void HideThis() {
            //UI를 숨긴다
            gameObject.SetActive(false);
        }

        public void UpgradeTower() {
            selectedTile.UpgradeTower();
        }
    }

}
