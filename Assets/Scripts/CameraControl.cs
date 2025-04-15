using UnityEngine;

namespace MyDefence {
    public class CameraControl : MonoBehaviour {
        #region fields
        //카메라 전후좌우 이동 속도
        public float speed = 5f;
        //카메라 확대/축소 속도
        public float zoomSpeed = 100f;
        Vector3 mousePos;
        float mousex, mousey;
        //카메라 이동 감지 영역
        float border = 30f;
        //카메라 이동 가능 판별 플래그
        bool canMove = true;
        #endregion

        private void Update() {
            if(GameManager.IsGameOver) {
                return;
            }
            if (Input.GetKeyDown(KeyCode.Escape)) {
                canMove = !canMove;
            }

            if (!canMove) return;
            //WASD로 카메라 이동하기
            if (Input.GetKey(KeyCode.W ) || Input.GetKey(KeyCode.UpArrow)) {
                transform.Translate(Vector3.forward * speed * Time.deltaTime, Space.World);
            }
            if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow)) {
                transform.Translate(Vector3.back * speed * Time.deltaTime, Space.World);
            }
            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) {
                transform.Translate(Vector3.left * speed * Time.deltaTime, Space.World);
            }
            if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) {
                transform.Translate(Vector3.right * speed * Time.deltaTime, Space.World);
            }
            //마우스 휠로 카메라 줌하기
            /*
            if (Input.GetAxis("Mouse ScrollWheel") > 0){
                transform.Translate(Vector3.forward * zoomSpeed * Time.deltaTime, Space.Self);
            } else if (Input.GetAxis("Mouse ScrollWheel") < 0) {
                transform.Translate(Vector3.back * zoomSpeed * Time.deltaTime, Space.Self);
            }*/

            float axisValue = Input.GetAxis("Mouse ScrollWheel");
            Vector3 scroll = transform.position;
            scroll.y -= axisValue * zoomSpeed * Time.deltaTime;
            scroll.y = Mathf.Clamp(scroll.y, 10f, 50f); //카메라 높이 제한
            transform.position = scroll;

            //화면 가장자리에 마우스 가져다 대면 카메라 이동하기
            mousePos = Input.mousePosition;
            mousex = mousePos.x; mousey = mousePos.y;
            if (mousey > Screen.height - border && mousey < Screen.height) {
                transform.Translate(Vector3.forward * speed * Time.deltaTime, Space.World);
            }
            if (mousey < border && mousey > 0) {
                transform.Translate(Vector3.back * speed * Time.deltaTime, Space.World);
            }
            if (mousex < border && mousex > 0) {
                transform.Translate(Vector3.left * speed * Time.deltaTime, Space.World);
            }
            if (mousex > Screen.width - border && mousex < Screen.width) {
                transform.Translate(Vector3.right * speed * Time.deltaTime, Space.World);
            }
            
        }
    }
}