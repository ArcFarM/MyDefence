using UnityEngine;
using System.Collections.Generic;
using Unity.VisualScripting;

namespace MyDefence {

    public class EnemyControl : MonoBehaviour {

        #region Fields
        //적 스탯
        float speed;
        [SerializeField] float init_speed = 4f;
        [SerializeField] float init_health = 100f;
        [SerializeField] int reward = 50;
        float health;
        
        //사망 시 출력할 이펙트
        public GameObject deathEffect;
        GameObject effectDummy;

        //도착 시 출력할 이펙트
        public GameObject arriveEffect;
        GameObject arriveDummy;
        public bool isArrive = false;

        //적 이동 경로 관련
        Transform target;
        int index = 0;
        Vector3 dir = new Vector3(0, 0, 0);
        #endregion

        public float Get_Health {
            get { return health; }
        }
        public float Max_Health {
            get { return init_health; }
        }

        //
        void Start() {
            target = Get_Waypoints.waypoints[index];
            dir = target.position - transform.position;
            health = init_health;
            speed = init_speed;
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
                else {
                    //종점 도착 시 라이프 감소
                    isArrive = true;
                    PlayerStats.LoseLife(1);
                    WaveManager.enemyCount--;
                    Destroy(gameObject);
                }

            }
        }

        public void TakeDamage(float damage) {
            health -= damage;
            //Debug.Log("현재 체력 : " + health);
            if (health <= 0) {
                //사망 이펙트 출력
                effectDummy = Instantiate(deathEffect, transform.position, Quaternion.identity);
                Destroy(effectDummy, 2f); //2초 후 이펙트 삭제
                //적 오브젝트 삭제
                Kill(gameObject);
            }
        }
         void Kill(GameObject enemy) {
           PlayerStats.GainMoney(reward);
            WaveManager.enemyCount--;
            Destroy(enemy);
         }
         
        public void SetSpeed(float val) {
            speed = val;
        }

        public float GetInitSpeed() {
            return init_speed;
        }
    }
}
