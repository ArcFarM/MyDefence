using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

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

    //코루틴
    IEnumerator blinkCoroutine;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //글자 투명화
        titleText.color = new Color(titleText.color.r, titleText.color.g, titleText.color.b, 0);
        StartCoroutine(LoadScene());
        StartCoroutine(StartBlink());
    }

    private void Update() {
        if (anykey) {
            //press anykey가 활성화되면 어떤 키를 눌러도 씬 활성화
            //Debug.Log("anykey activated");
            if (Input.anyKeyDown) {
                StopAllCoroutines();
                Debug.Log("LoadScene");
                SceneManager.LoadScene("MainMenu");
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
        yield return new WaitForSeconds(timer + anykeyLoader);
        Debug.Log("LoadScene");
        StopAllCoroutines();
        SceneManager.LoadScene("MainMenu");
    }
}
