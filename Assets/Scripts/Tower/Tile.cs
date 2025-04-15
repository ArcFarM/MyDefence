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
        TowerBluePrint tb;

        //표기 축약용
        BuildManager bm;

        //타워 건설 효과
        public GameObject buildEffect;

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
            if (!bm.CheckMoney) {
                renderer.material = cannotMat;
            }
            else if(!bm.CannotBuild) renderer.material = filledMat;
        }

        private void OnMouseExit() {
            //타일위에 UI가 있거나, 타워 설치하는 것이 아닌 경우 활성화되지 않아야함
            if (EventSystem.current.IsPointerOverGameObject()) return;
            renderer.material = defaultMat;
        }

        private void OnMouseDown() {
            //타일위에 UI가 있거나, 타워 프리팹이 할당되지 않았거나, 타워가 존재하는 경우 설치하지 않음
            if (EventSystem.current.IsPointerOverGameObject() || bm.CannotBuild
                || tower != null || !bm.CheckMoney) {
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
    }
}

