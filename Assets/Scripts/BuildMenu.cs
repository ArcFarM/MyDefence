using UnityEngine;


namespace MyDefense {
    public class BuildMenu : MonoBehaviour {
        public static void MGButton() {
            //BuildManager의 tower
            BuildManager.Instance.SetTowerBuild(BuildManager.Instance.machineGunPrefab);
        }

        public static void MissileButton() {
            BuildManager.Instance.SetTowerBuild(BuildManager.Instance.missileTowerPrefab);
        }
    }

}
