using UnityEngine;
using TMPro;

namespace Sample {
    public class PlayerMove : MonoBehaviour {
        public Transform target;
        public float speed = 5f;
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        TargetTest tt;

        public TextMeshProUGUI xvalue;
        public TextMeshProUGUI yvalue;

        void Start() {
            tt = target.GetComponent<TargetTest>();

            tt.Set_A(100);
            tt.val_b = 200;
        }

        // Update is called once per frame
        void Update() {
            /* 지정된 좌표에 이동시키기
             * Vector3 dir = target.position - transform.position;
            transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);*/

            /*
             * Input System에 따른 자유 이동
             */
            if(Input.GetKey(KeyCode.W)) {
                transform.Translate(Vector3.forward * speed * Time.deltaTime, Space.World);
            }
            if (Input.GetKey(KeyCode.S)) {
                transform.Translate(Vector3.back * speed * Time.deltaTime, Space.World);
            }
            if (Input.GetKey(KeyCode.A)) {
                transform.Translate(Vector3.left * speed * Time.deltaTime, Space.World);
            }
            if (Input.GetKey(KeyCode.D)) {
                transform.Translate(Vector3.right * speed * Time.deltaTime, Space.World);
            }
            if(Input.GetButtonDown("Jump")) {
                Debug.Log("Jump");
            }

            /*
             GetAxis : 컨트롤러를 통해 전후좌우를 제어 - 0에서 1까지의 정도로 입력 강도를 나타냄
             */

            /*
             마우스 포인터의 위치 가져오기
             */
            Vector3 mousePos = Input.mousePosition;

            xvalue.text = "X : " + ((int)mousePos.x).ToString();
            yvalue.text = "Y : " + ((int)mousePos.y).ToString();
        }
    }
}

