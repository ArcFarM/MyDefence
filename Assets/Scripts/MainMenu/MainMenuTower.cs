using UnityEngine;

namespace MyDefence {
    public class MainMenuTower : MonoBehaviour {

        //일정 주기로 effect를 발생
        float currTime = 0f;
        public float effectTimer;
        public ParticleSystem effect;

        //일정한 속도로 끊임없이 회전
        public float rotateSpeed;

        private void Update() {
            transform.Rotate(Vector3.up, rotateSpeed * Time.deltaTime);
            currTime += Time.deltaTime;
            if(currTime >= effectTimer) {
                currTime = 0f;
                effect.Play();
            }
        }
    }
}

