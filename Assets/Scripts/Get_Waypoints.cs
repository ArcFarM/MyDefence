using UnityEngine;

namespace MyDefence {
    public class Get_Waypoints : MonoBehaviour {
        #region
        public static Transform[] waypoints;
        #endregion
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Awake() {
            waypoints = new Transform[transform.childCount];
            for (int i = 0; i < waypoints.Length; i++) {
                waypoints[i] = transform.GetChild(i);
            }
        }

        void Start() {
            foreach (Transform waypoint in waypoints) {
                //Debug.Log(waypoint.position);
            }
        }
        // Update is called once per frame
        void Update() {

        }
    }
}
