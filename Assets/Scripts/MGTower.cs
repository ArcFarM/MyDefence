using System.Collections;
using UnityEngine;

namespace MyDefense {
    public class MGTower : MonoBehaviour {

        #region fields
        //사거리
        public float attackRange = 7f;
        //추적할 게임 오브젝트의 태그
        public string TagtoFind = "Enemy";
        Transform target;

        //터렛 헤드 회전
        public Transform partToRotate;
        //회전 속도
        public float turnSpeed = 1f;
        //발사할 총알
        public GameObject bullet;
        public Transform firePoint;

        //발사 타이머
        float timer = 1f;
        #endregion
        void Start() {
        }
        void Update() {
            //타이머 구현 방법 2. InvokeRepeating
            //인자 1(반복할 대상)을 인자 2(지연 시간)만큼 대기했다가 인자 3(반복 주기)초 마다 실행함
            InvokeRepeating("UpdateTarget", 0, 0.5f);
            Find_and_Rotate();

            timer -= Time.deltaTime;

            if (timer <= 0) {
                timer = 1f;
                Tower_Attack();
            }
        }

        //타워가 적을 발견하여 추적
        void Find_and_Rotate() {
            if(target == null) {
                UpdateTarget();
                return;
            }
            Vector3 dir = target.position - transform.position;
            Quaternion targetRotation = Quaternion.LookRotation(dir);
            Quaternion lookRotation = Quaternion.Lerp(partToRotate.rotation, targetRotation, Time.deltaTime * turnSpeed);
            partToRotate.rotation = Quaternion.Euler(0, lookRotation.eulerAngles.y, 0);
        }
        //타워가 매초 공격을 실시함
        void Tower_Attack() {
            if (target == null) {
                return;
            } else {
                Shoot_Bullet();
            }
        }

        void Shoot_Bullet() {
            //총알을 생성하고 발사
            Instantiate(bullet, firePoint.position, Quaternion.identity);
            BulletFunction bullet_bf = bullet.GetComponent<BulletFunction>();
            if (bullet_bf != null) bullet_bf.Set_Target(target);
        }

        void OnDrawGizmosSelected() {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, attackRange);
        }

        //타이머 구현 방법 1. 코루틴
        IEnumerator Tower_Update() {
            UpdateTarget();
            yield return new WaitForSeconds(0.5f);
        }

        void UpdateTarget() {
            GameObject[] Enemies = GameObject.FindGameObjectsWithTag(TagtoFind);

            float min_dist = float.MaxValue;

            //현재 가장 가까운 대상을 구한다
            foreach(var enemy in Enemies) {
                float dist = Vector3.Distance(transform.position, enemy.transform.position);
                if (min_dist > dist) {
                    min_dist = dist;
                    target = enemy.transform;
                }
            }
            
            //대상이 존재하지 않거나, 사거리 밖에 존재함
            if(min_dist > attackRange) {
                target = null;
                return;
            }
        }
    }
    }

