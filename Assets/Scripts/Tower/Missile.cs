using UnityEngine;

namespace MyDefence {
    public class Missile : Projectile {
        //공격 범위
        public float dmgRadius = 3.5f;
        //추적 태그
        public string targetTag = "Enemy";
        //기즈모를 이용하여 공격 범위 표현하기
        void OnDrawGizmos() {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, dmgRadius);
        }
        //투사체 공격력
        [SerializeField] float dmg_val  ;
        //Hit_Target() 오버라이드
        protected override void Target_Hit() {
            if (target != null) {
                //타격 시 발생할 효과 추가
                GameObject effectGo = Instantiate(bulletImpact, transform.position, Quaternion.identity);
                Destroy(effectGo, 2f);

                Explosion();
                Destroy(gameObject);
            }
        }

        void Explosion() {
            //해당 좌표에서 해당 범위만큼의 오브젝트 탐색
            Collider[] colliders = Physics.OverlapSphere(transform.position, dmgRadius);
            foreach (var collider in colliders) {
                if (collider.tag == targetTag) {
                    float dist = Vector3.Distance(transform.position, collider.transform.position);
                    float damage = dmg * ((dmgRadius - dist) / dmgRadius);
                    //Give_Damage(collider.transform);
                    EnemyControl enemy = collider.GetComponent<EnemyControl>();
                    if (enemy != null) {
                        enemy.TakeDamage(damage);
                    }
                }
            }
        }

        private void Start() {
            dmg = dmg_val;
        }


    }
}
