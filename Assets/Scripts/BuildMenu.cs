using UnityEngine;


namespace MyDefense {
    public class BuildMenu : MonoBehaviour {
        public void MGTowerButton() {
            //BuildManager의 tower
            BuildManager.Instance.SetTowerBuild(BuildManager.Instance.machineGunPrefab);
        }
    }

}
