using UnityEngine;


namespace MyDefense {
    public class BuildMenu : MonoBehaviour {

        #region Fields
        public TowerBluePrint machinegunTower;
        public TowerBluePrint missileTower;
        public TowerBluePrint laserTower;
        #endregion
        public void MGButton() {
            BuildManager.Instance.SetTowerBuild(machinegunTower);
        }

        public void MissileButton() {
            BuildManager.Instance.SetTowerBuild(missileTower);
        }

        public void LaserButton() {
            BuildManager.Instance.SetTowerBuild(laserTower);
        }
    }

}
