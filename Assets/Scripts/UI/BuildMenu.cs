using System.Linq;
using UnityEngine;


namespace MyDefence {
    public class BuildMenu : MonoBehaviour {

        #region Fields
        enum Lv1Towers {machinegun, missile, laser};

        public TowerBluePrint[] lv1towers;

        BuildManager bm;

        private void Start() {
            bm = BuildManager.Instance;
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
