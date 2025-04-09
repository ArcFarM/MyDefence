using UnityEngine;


namespace MyDefense {
    public class BuildMenu : MonoBehaviour {

        #region Fields
        public TowerBluePrint machinegunTower;
        public TowerBluePrint missileTower;
        #endregion
        public void MGButton() {
            BuildManager.Instance.SetTowerBuild(machinegunTower.towerPrefab);
        }

        public void MissileButton() {
            BuildManager.Instance.SetTowerBuild(missileTower.towerPrefab);
        }
    }

}
