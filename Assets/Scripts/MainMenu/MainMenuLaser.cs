using System.Collections;
using UnityEngine;

namespace MyDefence {
    public class MainMenuLaser : MonoBehaviour {
        //일정 주기마다 effect를 발생
        public LineRenderer laser;
        public ParticleSystem effect;
        float currTimer = 0f;
        public float effectTimer;
        float effectTime = 1f;
        float effectTimeNow = 0f;

        //발사 후 30 ~ 120도 중 무작위 값으로 회전
        public float minAngle;
        public float maxAngle;
        public float rotateSpeed;
        float randomAngle;
        Quaternion init_rotation;

        //effect와 laser 출력 지점
        public Transform effectStart;
        public Transform effectEnd;

        private void Start() {
            init_rotation = transform.rotation;
            laser.enabled = false;
            effect.Stop();
        }

        private void Update() {

            currTimer += Time.deltaTime;
            if (currTimer >= effectTimer) {
                Debug.Log("PlayLaser");
                currTimer = 0f;
                StartCoroutine(EffectCoroutine());
                StartCoroutine(RandomRotateCoroutine());
            }
        }

        IEnumerator RandomRotateCoroutine() {
            randomAngle = Random.Range(minAngle, maxAngle);
            if(randomAngle >= -20f && randomAngle <= 20f) {
                if(randomAngle < 0f) {
                    randomAngle = -20f;
                }
                else {
                    randomAngle = 20f;
                }
            }
            Quaternion new_rotation = Quaternion.Euler(init_rotation.x, init_rotation.y + randomAngle, init_rotation.z);
            //new_rotation으로 회전
            while(Quaternion.Angle(transform.rotation, new_rotation) > 0.1f) {
                transform.rotation = Quaternion.RotateTowards(transform.rotation, new_rotation, rotateSpeed * Time.deltaTime);
                yield return null;
            }
            yield return null;
        }

        IEnumerator EffectCoroutine() {
            effect.Play();
            laser.enabled = true;

            effectTimeNow = 0f;
            effect.transform.position = effectStart.position;

            Debug.Log("EffectCoroutine Statred");
            while (effectTimeNow < effectTime) {
                effectTimeNow += Time.deltaTime;
                laser.SetPosition(0, effectStart.position);
                laser.SetPosition(1, effectEnd.position);
                yield return null;
            }
            laser.enabled = false;
            effect.Stop();
            yield return new WaitForSeconds(effectTimer);
        }
    }

}
