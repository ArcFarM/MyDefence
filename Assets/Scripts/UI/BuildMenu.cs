using System.Linq;
using TMPro;
using UnityEngine;


namespace MyDefence {
    public class BuildMenu : MonoBehaviour {

        #region Fields
        enum Lv1Towers {machinegun, missile, laser};

        public TowerBluePrint[] lv1towers;
        public TowerBluePrint[] lv2towers;
        public GameObject[] towerlist;

        BuildManager bm;

        private void Start() {
            bm = BuildManager.Instance;

            int index = 0;
            foreach(GameObject go in towerlist) {
                go.GetComponentInChildren<TextMeshProUGUI>().text
                     = lv1towers[index].towerCost.ToString();
                index++;
            }
        }
        #endregion
        public void MGButton() {
            bm.SetTowerBuild(lv1towers[(int)Lv1Towers.machinegun]);
        }

        public void MissileButton() {
            bm.SetTowerBuild(lv1towers[(int)Lv1Towers.missile]);
        }

        public void LaserButton() {
            bm.SetTowerBuild(lv1towers[(int)Lv1Towers.laser]);
        }
    }

}
