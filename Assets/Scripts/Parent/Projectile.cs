using UnityEngine;

namespace MyDefence {
    public class Projectile : MonoBehaviour {

        //착탄 지점
        public Transform target;
        //총알의 속력
        public float velocity = 70f;
        //착탄 시 발생할 효과
        public GameObject bulletImpact;
        //효과 수명
        float lifeTime = 2;
        //투사체 공격력
        [SerializeField] protected float dmg = 50f;
        void Update() {
            if(target != null) {
                Vector3 dir = target.position - transform.position;
                transform.LookAt(target.position);
                /*Quaternion targetRotation = Quaternion.LookRotation(dir);
                Quaternion lookRotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime * velocity);
                transform.rotation = lookRotation;*/
                if (dir.magnitude < Time.deltaTime * velocity) {
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

        protected virtual void Target_Hit() {
            if (target != null) {
                //타격 시 발생할 효과 추가
                GameObject effectGo = Instantiate(bulletImpact, transform.position, Quaternion.identity);

                Give_Damage(target);
                Destroy(gameObject);
                Destroy(effectGo, lifeTime);
            }
        }

        protected void Give_Damage(Transform t) {
            EnemyControl enemy;
            if(t.TryGetComponent<EnemyControl>(out enemy) == true) {
                enemy.TakeDamage(dmg);
            }
        }
    }
}