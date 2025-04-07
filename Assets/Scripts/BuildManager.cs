using UnityEngine;

namespace MyDefense {
    public class BuildManager : MonoBehaviour {
        static BuildManager instance;

        #region Singleton Initialization
        public static BuildManager Instance {
            get {
                if (instance == null) instance = new BuildManager();
                return instance;
            }
        }

        void Awake() {
            if (instance != null) {
                Destroy(gameObject);
                return;
            }
            instance = this;
        }
        #endregion

        public GameObject towerToBuild;
        public GameObject machineGunPrefab;
        public GameObject missileTowerPrefab;

        //타워 프리팹 얻어오기
        public GameObject GetTowerBuild() {
            return towerToBuild;
        }

        //타워 프리팹 저장하기
        public void SetTowerBuild(GameObject tower) {
            towerToBuild = tower;
        }
    }
}