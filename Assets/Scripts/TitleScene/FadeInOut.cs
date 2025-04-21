using System.Collections;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace MyDefence {
    public class FadeInOut : MonoBehaviour {
        // Animator 컴포넌트 (Inspector에서 할당하거나 GetComponent로 자동 설정)
        public Animator animator;

        // 재생할 애니메이션 클립들 (Inspector에서 할당)
        public  AnimationClip FadeIn;
        public  AnimationClip FadeOut;

        void Awake() {
            gameObject.GetComponent<Image>().color = new Color(0, 0, 0, 1); // 검은색으로 초기화
        }

        public IEnumerator Do_FadeOut(string scene_name) {
            // FadeOut 상태를 재생
            animator.SetBool("Fade", true);

            yield return new WaitForSeconds(FadeOut.length);
            if(scene_name != null) {
                // FadeOut 애니메이션이 끝난 후 씬 전환
                SceneManager.LoadScene(scene_name);
            }
            else {
                // FadeOut 애니메이션이 끝난 후 게임 종료
                Application.Quit();
            }
        }
    }
}
