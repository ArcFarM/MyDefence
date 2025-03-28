using UnityEngine;
using System.Collections.Generic;
using Unity.VisualScripting;

namespace MyDefense {

    public class EnemyControl : MonoBehaviour {

        #region Fields
        float speed = 4f;
        Transform target;
        int index = 0;
        Vector3 dir = new Vector3(0, 0, 0);
        #endregion

        //
        void Start() {
            target = Get_Waypoints.waypoints[index];
            dir = target.position - transform.position;
        }

        //
        void Update() {
            
            transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

            if(Vector3.Distance(transform.position, target.position) < 0.1f) {
                if (index < Get_Waypoints.waypoints.Length) {
                    target = Get_Waypoints.waypoints[index];
                    dir = target.position - transform.position;
                    index++;
                }
                else GameObject.Destroy(gameObject);
            }
        }
    }
}
