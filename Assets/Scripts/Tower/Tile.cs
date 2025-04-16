using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

namespace MyDefence {
    public class Tile : MonoBehaviour {

        //구분용 머터리얼
        public Material defaultMat;
        public Material filledMat;
        public Material cannotMat;
        Renderer renderer;

        //설치할 타워
        GameObject tower;
        [SerializeField] TowerBluePrint tb;

        //표기 축약용
        BuildManager bm;

        //타워 건설 및 판매 효과
        public GameObject buildEffect;
        public GameObject sellEffect;

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start() {
            bm = BuildManager.Instance;
            renderer = GetComponent<Renderer>();
            defaultMat = renderer.material;
        }

        // Update is called once per frame
        void Update() {

        }

        private void OnMouseEnter() {
            //타일위에 UI가 있거나, 타워 설치하는 것이 아닌 경우 활성화되지 않아야함
            if(EventSystem.current.IsPointerOverGameObject()) return;
            if (!bm.CannotBuild && !bm.CheckMoney) {
                renderer.material = cannotMat;
                return;
            }
            renderer.material = filledMat;
        }

        private void OnMouseExit() {
            //타일위에 UI가 있거나, 타워 설치하는 것이 아닌 경우 활성화되지 않아야함
            if (EventSystem.current.IsPointerOverGameObject()) return;
            renderer.material = defaultMat;
        }

        private void OnMouseDown() {

            if (tower != null) {
                bm.SetTowerBuild(null);
                //타워가 존재하는 경우 UI를 보여준다
                //Debug.Log("Run bm.Selecttile");
                bm.SelectTile(this);

                return;
            }

            //타워를 지을 돈이 없는 경우 설치하지 않음
            if (!bm.CheckMoney) {
                bm.SetTowerBuild(null);
                return;
            }

            //타일위에 UI가 있거나, 타워 프리팹이 할당되지 않았거나, 타워가 존재하는 경우 설치하지 않음
            if (EventSystem.current.IsPointerOverGameObject()) { 
                bm.SetTowerBuild(null);
                return;
            }
            if (bm.CannotBuild) { 
                bm.SetTowerBuild(null);
                return;
            }

            BuildTower();
        }

        void BuildTower() {
            //건설할 타워 정보 받아오기
            tb = bm.GetTowerBuild();
            //타워 가격만큼 차감하고 설치
            PlayerStats.SpendMoney(tb.towerCost);
            tower = Instantiate(tb.towerPrefab, transform.position, Quaternion.identity);
            //타워 설치 후 타워 프리팹 초기화
            bm.SetTowerBuild(null);
            //효과 표시 후 삭제
            GameObject dummyEffect = Instantiate(buildEffect, transform.position, Quaternion.identity);
            Destroy(dummyEffect, 2f);
        }

        public void UpgradeTower() {
            tb.towerLevel++;
            //타워 업그레이드 가능 여부 체크
            if (tower == null) {
                Debug.Log("타워가 존재하지 않아서 업그레이드 불가");
                return;
            } 
            
            if (tb.upgradePrefab.IsUnityNull()) {
                Debug.Log("업그레이드할 타워가 존재하지 않아서 업그레이드 불가");
                return;
            } 
            
            if(!PlayerStats.CheckMoney(tb.upgradeCost)) {
                Debug.Log("금액이 부족해서 업그레이드 불가");
                return;
            }

            //타워 가격만큼 차감
            PlayerStats.SpendMoney(tb.towerCost);
            //기존 타워 철거 및 타워 설치
            Destroy(tower);
            tower = Instantiate(tb.upgradePrefab, transform.position, Quaternion.identity);
            //업그레이드 효과
            GameObject dummyEffect = Instantiate(buildEffect, transform.position, Quaternion.identity);
            Destroy(dummyEffect, 2f);
            //UI 갱신
            bm.tileUI.ToggleThis(this);
            bm.tileUI.ToggleThis(this);
        }

        public void SellTower() {
            //Debug.Log("Tower null check");
            //타워가 존재하지 않으면 판매 불가
            if (tower == null) {
                Debug.Log("타워가 존재하지 않아서 판매 불가");
                return;
            }
            //Debug.Log("Give Money");    
            //판매 금액 지급
            PlayerStats.GainMoney((int)tb.GetSellValue());
            Destroy(tower);
            tower = null;
            bm.SetTowerBuild(null);
            //판매 효과 추가
            GameObject dummyEffect = Instantiate(sellEffect, transform.position, Quaternion.identity);
            //UI 숨기기
            bm.tileUI.ToggleThis(this);
        }

        public TowerBluePrint GetTb() {
            return tb;
        }
    }
}

