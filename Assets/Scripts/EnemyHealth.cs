using UnityEngine;
using UnityEngine.UI;

namespace MyDefence {
    public class EnemyHealth : MonoBehaviour {
        //적의 체력을 fillamount를 통해 보이게 하기

        public Image health_now;
        EnemyControl enemy;
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start() {
            enemy = gameObject.GetComponent<EnemyControl>();
        }

        // Update is called once per frame
        void Update() {
            health_now.fillAmount = enemy.Get_Health / enemy.Max_Health;
        }
    }
}

