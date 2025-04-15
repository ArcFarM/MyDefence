using Unity.VisualScripting;
using UnityEditor.SceneManagement;
using UnityEngine;

namespace MyDefence {
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
        //tileUI 관련
        public TileUI tileUI;
        public Tile tile;

        #region Property
        public bool CheckMoney {
            get {
                if (towerToBuild == null) return false;  
                if (towerToBuild.towerPrefab == null) return false;
                else return PlayerStats.Money >= towerToBuild.towerCost;
            }
        }

        public bool CannotBuild {
            get {
                if(towerToBuild == null) return true;
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

        public void SelectTile(Tile t) {
            Debug.Log("is tile == t?");
            //같은 타일 선택 시 선택 해제
            if (tile == t) {
                UnselectTile();
                return;
            }

            tile = t;
            Debug.Log("run showthis");
            tileUI.ShowThis(t);
        }

        public void UnselectTile() {
            tileUI.HideThis();
        }
    }
}