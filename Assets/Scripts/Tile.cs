using UnityEngine;
using UnityEngine.EventSystems;

namespace MyDefense {
    public class Tile : MonoBehaviour {

        //구분용 머터리얼
        public Material defaultMat;
        public Material filledMat;
        Renderer renderer;

        GameObject tower;
        

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start() {
            renderer = GetComponent<Renderer>();
            defaultMat = renderer.material;
        }

        // Update is called once per frame
        void Update() {

        }

        private void OnMouseEnter() {
            //타일위에 UI가 있거나, 타워 설치하는 것이 아닌 경우 활성화되지 않아야함
            if(EventSystem.current.IsPointerOverGameObject()) return;
            if(BuildManager.Instance.towerToBuild == null) return;
            renderer.material = filledMat;
        }

        private void OnMouseExit() {
            //타일위에 UI가 있거나, 타워 설치하는 것이 아닌 경우 활성화되지 않아야함
            if (EventSystem.current.IsPointerOverGameObject()) return;
            if (BuildManager.Instance.towerToBuild == null) return;
            renderer.material = defaultMat;
        }

        private void OnMouseDown() {
            //타일위에 UI가 있거나, 타워 프리팹이 할당되지 않았거나, 타워가 존재하는 경우 설치하지 않음
            if(EventSystem.current.IsPointerOverGameObject() ||
            BuildManager.Instance.towerToBuild == null ||
            tower != null) {
                BuildManager.Instance.towerToBuild = null;
                return;
            }

            tower = Instantiate(BuildManager.Instance.towerToBuild, transform.position, Quaternion.identity);
            //타워 설치 후 타워 프리팹 초기화
            BuildManager.Instance.towerToBuild = null;
        }
    }
}

