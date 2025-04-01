using UnityEngine;

namespace Sample {
    public class RotationTest : MonoBehaviour {

        public GameObject target;

        Vector3 dir;
        void Start() {
            /*
            //물체를 회전시키는 방법 : 해당 물체의 회전을 특정한 좌표로 설정하기
            transform.rotation = Quternion.Euler(0, 0, 0);

            //물체 회전 방법 2 : 해당 물체를 특정한 속도로 자전시키기
            transform.Rotate(오일러값, 공간 - 필요에 따라 없을 수 있음);

            //물체 회전 방법 3 : 해당 물체를 기준으로 공전시키기
            transform.RotateAround(대상 지점, 방향, 속도);

            //물체 회전 방법 4 : 해당 방향으로 회전시키기

             Vector3 dir = target.position - transform.position;
            lookrotation 메서드 : 해당 벡터를 바라보는 회전값 구하기
             Quaternion lookRotation = Quaternion.LookRotation(dir);
            transform.rotation = lookRotation;
             
            //물체 회전 방법 5 : 선형 보간을 이용한 회전
            Quaternion.Lerp(시작 회전값, 끝 회전값, 비율);

            //물체 회전 방법 6 : 부분적으로 (특정 좌표만) 회전 시키기
            Vector3 eulerRotation = lookRotation.eulerAngles;
            this.transform.rotation = Quaternion.Euler(0, eulerRotation.y, 0);
             */
            dir = target.transform.position - transform.position;
            //dir.y = 0;

            Quaternion lookRotation = Quaternion.LookRotation(dir);
            transform.rotation = lookRotation;
        }

        void Update() {
            /*
             회전과 이동을 동시에 하기
             */
            if(Vector3.Distance(transform.position, target.transform.position) > 0.1f) {
               transform.Translate(dir.normalized * Time.deltaTime * 2f, Space.World);
            }

        }
    }
}