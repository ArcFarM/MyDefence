using Unity.VisualScripting;
using UnityEditor.SceneManagement;
using UnityEngine;

namespace MyDefense {
    public class BuildManager : MonoBehaviour {
        static BuildManager instance;

        #region Singleton Initialization
        public static BuildManager Instance {
            get {
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

        [SerializeField] TowerBluePrint towerToBuild = null;

        #region Property
        public bool CheckMoney {
            get {
                if (towerToBuild.towerPrefab == null) return false;
                return PlayerStats.Money >= towerToBuild.towerCost;
            }
        }

        public bool CannotBuild {
            get {
                return towerToBuild.towerPrefab == null;
            }
        }
        #endregion

        //타워 프리팹 얻어오기
        public TowerBluePrint GetTowerBuild() {
            return towerToBuild;
        }

        //타워 프리팹 저장하기
        public void SetTowerBuild(TowerBluePrint tower) {
            towerToBuild = tower;
        }

        public int GetBuildCost() {
            return towerToBuild.towerCost;
        }
    }
}