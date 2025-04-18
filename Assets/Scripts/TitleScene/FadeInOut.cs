using System.Collections;
using UnityEngine.UI;
using UnityEngine;

namespace MyDefence {
    public class FadeInOut : MonoBehaviour {
        // Animator 컴포넌트 (Inspector에서 할당하거나 GetComponent로 자동 설정)
        public Animator animator;

        // 재생할 애니메이션 클립들 (Inspector에서 할당)
        public AnimationClip FadeIn;
        public AnimationClip FadeOut;

        void Awake() {
            gameObject.GetComponent<Image>().color = new Color(0, 0, 0, 1); // 검은색으로 초기화
        }

        public IEnumerator Do_FadeOut() {
            // FadeOut 상태를 재생
            animator.SetBool("Fade", true);
            Debug.Log(animator.GetBool("Fade"));

            yield return new WaitForSeconds(FadeOut.length);
        }
    }
}
