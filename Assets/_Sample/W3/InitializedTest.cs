using UnityEngine;

public class InitializedTest : MonoBehaviour
{
    
    //1. 필드 초기화
    [SerializeField] int fieldValue = 10;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //2. Inpsector에서 설정한 값으로 덮어씌움
        Debug.Log(fieldValue);
        //3. Start 메서드에서 설정한 값으로 덮어씌움
        fieldValue = 20;
        Debug.Log(fieldValue);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
