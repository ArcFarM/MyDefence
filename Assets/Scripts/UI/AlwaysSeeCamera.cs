using UnityEngine;
using UnityEngine.UI;

namespace MyDefence {
    public class AlwaysSeeCamera : MonoBehaviour {
        //항상 메인 카메라를 바라보도록 설정
        private void Update() {
            transform.LookAt(Camera.main.transform.position);
        }
    }
}
