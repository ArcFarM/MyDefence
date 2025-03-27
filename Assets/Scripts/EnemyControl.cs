using UnityEngine;
using System.Collections.Generic;
using Unity.VisualScripting;

namespace MyDefense {

    public class EnemyControl : MonoBehaviour {

        #region Fields
        float speed = 4f;
        Vector3 targetPos;
        int index = 0;
        Vector3 dir = new Vector3(0, 0, 0);
        #endregion

        //
        void Start() {
            targetPos = Get_Waypoints.waypoints[index].position;
            dir = targetPos - transform.position;
        }

        //
        void Update() {
            
            transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

            if(Vector3.Distance(transform.position, targetPos) < 0.1f) {
                if (index < Get_Waypoints.waypoints.Length) {
                    targetPos = Get_Waypoints.waypoints[++index].position;
                    dir = targetPos - transform.position;
                }
                else GameObject.Destroy(gameObject);
            }
        }
    }
}
