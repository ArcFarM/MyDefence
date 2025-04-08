using UnityEngine;

namespace Sample {
    public class SerializeTest : MonoBehaviour {
        //.meta 파일을 생성하기 위한 빈 게임 오브젝트
        //.meta 파일은 Serialize 된 정보가 YAML 형식으로 저장되어 있음

        public int testValue = 1234;

        //씬에 게임오브젝트를 넣고 여기에 스크립트를 부착하면 관련 정보가 씬의 .meta 파일에 그대로 저장

        [SerializeField]
        //SerializeField는 private 변수도 Serialize 할 수 있도록 해줌
        private int testValue2 = 5678;
    }

}

