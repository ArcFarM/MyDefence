using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using MyDefence;

public class TitleScene : MonoBehaviour
{
    //씬 강제 로딩 대기 시간
    public float timer;
    //Press Anykey 로딩 대기 시간
    public bool anykey = false;
    public float anykeyLoader;
    //글자 깜빡임 시간
    public float blinkTimer;
    //깜빡일 글자
    public TextMeshProUGUI titleText;
    //한번만 작동하기 위한 Flag
    bool switchFlag = false;

    //화면 전환 시 페이드 아웃할 패널
    public FadeInOut fadeOutPanel;

    //코루틴
    IEnumerator blinkCoroutine;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //글자 투명화
        titleText.color = new Color(titleText.color.r, titleText.color.g, titleText.color.b, 0);
        StartCoroutine(ForceLoadScene());
        StartCoroutine(StartBlink());
    }

    private void Update() {
        if (anykey) {
            //press anykey가 활성화되면 어떤 키를 눌러도 씬 활성화
            //Debug.Log("anykey activated");
            if (Input.anyKeyDown && !switchFlag) {
                switchFlag = true;
                Debug.Log("LoadScene");
                StartCoroutine(LoadScene());
            }
            //글자 깜빡임 + 불필요한 호출 제거
            if (blinkCoroutine == null) {
                blinkCoroutine = TextBlink();
                StartCoroutine(blinkCoroutine);
            }
        }
    }

    IEnumerator TextBlink() {
        Debug.Log("TextBlink");
        float time = 0f;
        float new_alpha = 0f;
        while(time < blinkTimer) {
            time += Time.deltaTime;
            new_alpha += Time.deltaTime / blinkTimer;
            Color curr_color = titleText.color;
            Color new_color = new Color(curr_color.r, curr_color.g, curr_color.b, new_alpha);
            titleText.color = new_color;
            //Debug.Log(titleText.color.a);
            yield return null;
        }
        while (time < blinkTimer * 2) {
            time += Time.deltaTime;
            new_alpha -= Time.deltaTime / blinkTimer;
            Color curr_color = titleText.color;
            Color new_color = new Color(curr_color.r, curr_color.g, curr_color.b, new_alpha);
            titleText.color = new_color;
            //Debug.Log(titleText.color.a);
            yield return null;
        }
        yield return blinkTimer * 2;
        blinkCoroutine = null;
    }

    IEnumerator StartBlink() {
        yield return new WaitForSeconds(anykeyLoader);
        anykey = true;
        Debug.Log("StartBlink");
    }
    IEnumerator LoadScene() {
        Debug.Log("LoadScene");
        //페이드 아웃 패널 활성화
        fadeOutPanel.gameObject.SetActive(true);
        //페이드 아웃 애니메이션 시작
        yield return StartCoroutine(fadeOutPanel.Do_FadeOut("MainMenu"));
        //완료 대기 후 화면 전환
        yield return null;
    }

    IEnumerator ForceLoadScene() {
        //정해진 시간이 지나면 강제 시작
        yield return new WaitForSeconds(timer + anykeyLoader);
        //페이드 아웃 패널 활성화
        fadeOutPanel.gameObject.SetActive(true);
        //페이드 아웃 애니메이션 시작
        fadeOutPanel.Do_FadeOut("MainMenu");
    }
}
