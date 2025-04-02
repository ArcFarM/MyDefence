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

        public GameObject towerPrefab;
    }
}