using UnityEngine;

public class EventTest : MonoBehaviour
{
    int counter = 0;
    void Awake(){
        Debug.Log("Awake, 1번만 실행");
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Debug.Log("Start, 1번만 실행");        
    }

    void FixedUpdate(){
        if(counter == 0)
        Debug.Log("FixedUpdate, 초당 50회 고정 실행");
    }

    // Update is called once per frame
    void Update()
    {
        if(counter == 0)
        Debug.Log("Update, 1프레임 마다 실행");
    }

    void LateUpdate(){
        if(counter == 0)
        Debug.Log("LateUpdate, Update가 끝난 후 1 프레임 마다 실행");

        counter++;
    }

    void OnEnable(){
        Debug.Log("OnEnable, 활성화 될 때 1회 실행");
    }

    void OnDisable(){
        Debug.Log("OnDisable, 비활성화 될 때 1회 실행");
    }
}
