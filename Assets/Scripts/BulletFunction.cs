using UnityEngine;

namespace MyDefense {
    public class BulletFunction : MonoBehaviour {

        public Transform target;
        public float velocity = 70f;
        void Update() {
            if(target != null) {
                Vector3 dir = target.position - transform.position;
                if(dir.magnitude < Time.deltaTime * velocity) {
                    //이번 프레임에 대상에 도달하므로
                    Target_Hit();
                    return;
                }
                transform.Translate(dir.normalized * velocity * Time.deltaTime, Space.World);
            } else Destroy(gameObject);
        }

        public void Set_Target(Transform _target) {
            target = _target;
        }

        void Target_Hit() {
            if (target != null) {
                Destroy(target.gameObject);
                Destroy(gameObject);
            }
        }
    }
}