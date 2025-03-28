using UnityEngine;

public class PrefabTest : MonoBehaviour
{
    public GameObject go;
    public int row;
    public int col;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Instantiate(gameObject, new Vector3(0, 0, 0), Quaternion.identity) : 게임오브젝트를 스크립트로 생성하는 방법
        /*for(int i = 0; i < row; i++) {
            for(int j = 0; j < col; j++) {
                Instantiate(go, new Vector3(i * 2, 1, j * 2), Quaternion.identity);
            }
        }*/

        for (int i = 0; i < row; i++) {
            for (int j = 0; j < col; j++) {
                float xPos = Random.Range(-25f, 25f);
                float yPos = Random.Range(1f, 5f);
                float zPos = Random.Range(-25f, 25f);
                Instantiate(go, new Vector3(xPos, yPos, zPos), Quaternion.identity);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
