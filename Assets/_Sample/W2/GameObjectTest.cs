using UnityEngine;

public class GameObjectTest : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        /*
         * 방법 1 : this를 통한 컴포넌트 접근         
        this.gameObject.AddComponent<Rigidbody>();
        this.gameObject.GetComponent<Rigidbody>().useGravity = false;
        
        방법 2 : 필드 멤버에 public으로 선언하고 inspector를 통해 직접 연결하기
        gameObject.AddComponent<Rigidbody>();
        gameObject.GetComponent<Rigidbody>().useGravity = false;
        
        방법 3 : Tag를 통해 가져오기
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject enemy in enemies) {
            enemy.GetComponent<Rigidbody>().useGravity = false;
        }

        방법 4 : Instantiate를 통해 Prefab을 가져오기
        GameObject enemyPrefab = Resources.Load<GameObject>("Enemy");
        GameObject enemy = Instantiate(enemyPrefab, new Vector3(0, 0, 0), Quaternion.identity);

        방법 5 : 같은 종류, 기능들로 묶어 객체 가져오기 - 부모를 만들어서 자식에 접근하기
        Getchild를 통해 부모 오븢게트에서 자식 정보 가져오기

        */
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

/*
 게임 오브젝트에 접근하는 방법

1) this를 통해 컴포넌트를 추가하여 가져오기
2) 필드 멤버에 public으로 선언하고 inspector를 통해 직접 연결하기
3) Tag를 통해 가져오기
4) Instantiate를 통해 Prefab을 가져오기
5) 같은 종류, 기능들로 묶어 객체 가져오기 - 부모를 만들어서 자식에 접근하기
6) 싱글톤을 이용하여 static으로 선언된 객체 가져오기
 */