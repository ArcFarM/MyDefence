using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace MyDefence {
    public class SceneLoader : MonoBehaviour {
        public FadeInOut fadeOutPanel;
        public GameObject content;
        public Button[] levelButtons;

        //자동 스크롤에 필요한 요소
        public RectTransform scrollRect;
        public RectTransform contentRect;
        public Scrollbar scrollbar;

        //해금된 최대 레벨에 따라 잠금 해제   
        private void Start() {
            levelButtons = new Button[content.transform.childCount];
            for (int i = 0; i < levelButtons.Length; i++) {
                levelButtons[i] = content.transform.GetChild(i).GetComponent<Button>();
                int level = i + 1;
                //레벨 버튼에 레벨 번호를 설정
                levelButtons[i].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = level.ToString();
                Debug.Log(PlayerStats.GetBestLevel);
                if (PlayerStats.GetBestLevel >= level) {
                    levelButtons[i].interactable = true;
                }
                else {
                    levelButtons[i].interactable = false;
                }
            }

            //플레이할 레벨로 자동 스크롤

            //내 눈에 보이는 영역
            float scrollHeight = scrollRect.rect.height;
            GridLayoutGroup gridLayout = content.GetComponent<GridLayoutGroup>();
            //한 줄의 높이
            int buttonHeight = (int)(gridLayout.cellSize.y + gridLayout.spacing.y);
            //전체 영역의 크기
            float contentsHeight = buttonHeight * (levelButtons.Length / 5 + 1);
            //내가 스크롤할 영역
            if (contentsHeight > scrollHeight) {
                //전체 영역이 눈에 보이는 크기를 넘어간다면 스크롤바를 초과하는 만큼 내린다
                float scrollY = buttonHeight * (PlayerStats.GetBestLevel / 5);
                scrollbar.value = 1 - (scrollY / contentsHeight);
            }
            else {
                //전체 영역이 눈에 보이는 크기보다 작다면 스크롤바를 내리지 않는다
                scrollbar.value = 1;
            }
        }

        //버튼 클릭시 각 버튼에 해당하는 씬으로 이동
        public void LoadLevel(int level) {
            string sceneName;
            if(level < 10) sceneName = "Level0" + level.ToString();
            else sceneName = "Level" + level.ToString();
            Debug.Log("Trying to Load Scene " + sceneName);
            PlayerStats.GetCurrentLevel = level;
            StartCoroutine(fadeOutPanel.Do_FadeOut(sceneName));
        }



        public void BackMain() {
            StartCoroutine(fadeOutPanel.Do_FadeOut("MainMenu"));
        }
    }
}
