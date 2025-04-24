using UnityEngine;
using UnityEngine.UI;
using TMPro;
using MyDefence;
using System.Collections;

public class LevelClear : MonoBehaviour
{
    Animator animator;
    [SerializeField] TextMeshProUGUI levelText;
    public FadeInOut fadePanel;
    bool isAnimDone = false;
    bool isDisplayDone = false;

    private void Start() {
        animator = GetComponent<Animator>();
        levelText.text = "";

        PlayerStats.GetCurrentLevel++;
    }

    private void Update() {
        if (isDisplayDone) return;
        if (isAnimDone) {
            levelText.text = "0";
            StartCoroutine(LevelAnim());
            return;
        }
    }

    IEnumerator LevelAnim() {
        int level = PlayerStats.GetCurrentLevel;
        int counter = 0;
        while(counter < level) {
            levelText.text = (counter + 1).ToString();
            counter++;
            yield return new WaitForSeconds(1f / level);
        }

    }


    public void Continue() {
        int level = PlayerStats.GetCurrentLevel;
        Debug.Log(level);
        if (level < 10)
        StartCoroutine(fadePanel.Do_FadeOut("Level0"+level));
        else StartCoroutine(fadePanel.Do_FadeOut("Level" + level));
    }

    public void GoMainMenu() {
        StartCoroutine(fadePanel.Do_FadeOut("MainMenu"));
    }
}
