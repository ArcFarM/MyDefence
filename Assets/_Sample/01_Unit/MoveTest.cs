using UnityEngine;

namespace Sample {
    public class MoveTest : MonoBehaviour
    {
        //이동 목표 지점
        Vector3 target = new Vector3(7f, 1f, 8f);
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            
        }

        // Update is called once per frame
        void Update()
        {
            /*
             * 가장 기초적인 이동 방법
             * this.transform.position에 Vector3 값을 더하고 빼기
             * 내장된 forward, back, right, left, up, down 등을 사용 가능
             * 예시 :
             * this.transform.position += new Vector3(0.1f, 0, 0);
             */

            //프레임에 상관없이 일저한 이동을 제공하는 법 : Time.deltaTime을 이용 (한 프레임에 걸리는 시간)
            //예시 : this.transform.position += new Vector3(0.1f, 0, 0) * Time.deltaTime;

            //translate를 이용하여 이동 가능
            //예시 : this.transform.translate(Vector3.forward * 0.1f * Time.deltaTime);

            /*방향 찾기 : (목표 위치 좌표에서 현재 좌표 빼기)
            //Vector3 dir = targetPos - this.transform.position;
            Vector3는 3차원 벡터 -> 벡터의 정규화, 크기를 구하는 기능도 존재
            Magnitude = 벡터의 크기 (스칼라)를 구함
            normalized = 정규화하여 크기가 1로 변하여 방향 정보만 가짐
            //원하는 방향으로 이동하기 -> this.transform.Translate(dir.normalized * Time.deltaTime * Speed);
            */

            /*
             월드 공간 이용하기
            transform.Translate(Time.deltaTime * Speed * Vector3.forward , Space.World);
            Space.World = ? 월드 공간 좌표계를 따른다는 의미
            Space.Self = ? 자신의 좌표계 (오브젝트의 +Z 방향을 따른다는 의미)
             */
        }
    }
}

/*
    특정한 방향과 속도로 이동하는 법과
    목표지점을 지정하여 이동하는 법을 알아보는 기초 스크립트트
*/
