using System.Collections;
using UnityEngine;

namespace MyDefense {
    public class LaserTower : Tower {
        #region Fields
        //레이저 오브젝트와 레이저 적중시 효과
        public LineRenderer laser;
        public ParticleSystem laserImpact;
        public Light laserLight;

        //레이저 공격력
        public float damage;
        #endregion

        protected void Start() {
            laser.enabled = false;
            laserImpact.Stop();
            laserLight.enabled = false;
        }

        protected override void Update() {
            Find_and_Rotate();
            if (target == null) {
                if(laser.enabled == true) {
                    //타겟이 없으면 레이저 비활성화
                    laser.enabled = false;
                    laserImpact.Stop();
                    laserLight.enabled = false;
                }
                return;
            }
            if(timer >= 0) timer -= Time.deltaTime;
            Fire_Laser();
        }

        protected void Fire_Laser() {
            if (laser == null || target == null) return;
            
            if(laser.enabled == false) {
                //타겟이 있으면 레이저 활성화
                laser.enabled = true; 
                laserImpact.Play();
                laserLight.enabled = true;
            }
            //발사 지점이 시작 지점, 공격할 적이 끝 지점
            laser.SetPosition(0, firePoint.position);
            laser.SetPosition(1, target.position);
            //타격 지점으로 이펙트를 옮기고 활성화
            laserImpact.transform.position = target.position;
            //이펙트의 방향을 나를 바라보고, 타겟의 표면에서 이펙트가 나오도록 설정
            laserImpact.transform.LookAt(target.position);

            //공격 주기마다 공격력 만큼 적 체력 감소
            if (timer <= 0) {
                timer = timer_set;
                target.GetComponent<EnemyControl>().TakeDamage(damage);
            }
            //공격하고 있는 도중에는 적 이동속도 감소
            EnemyControl ec = target.GetComponent<EnemyControl>();
            ec.SetSpeed(ec.GetInitSpeed() * 0.6f);

        }
    }
}

