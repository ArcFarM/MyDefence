using UnityEngine;

namespace Sample {
    public class MoneyTest : MonoBehaviour {
        void Start() {
            Debug.Log("MoneyTest started");
        }
        void Update() {
        }
    }
}

/*
 시작 시 소지금 지급
 돈 현황을 파악할 수 있또록 UI를 표시
돈 지급, 돈 소모 등을 할 수 있는 버튼 구현
+ 돈이 모자라다면 구매를 할 수 없다는 것도 보여야 함
 */