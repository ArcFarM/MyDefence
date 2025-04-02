using UnityEngine;

namespace Sample {


    public class HitTest : MonoBehaviour {
        struct Box {
            public int height;
            public int width;
            public Vector3 center;
        }

        struct Circle {
            public int radius;
            public Vector3 center;
        }

        //대상 물체
        public Transform target;

        //물체의 이동속도
        public float speed = 5f;

        void Start() {
        }
        void Update() {
        }

        bool CheckBox(Box box_a, Box box_b) {
            //조건 1 : 두 Box의 x좌표 간 거리가 두 Box의 너비 합의 반보다 작아야 함
            bool cond_a = Mathf.Abs(box_a.center.x - box_b.center.x) < (box_a.width + box_b.width) / 2;
            //조건 2 : 두 Box의 y좌표 간 거리가 두 Box의 높이 합의 반보다 작아야 함
            bool cond_b = Mathf.Abs(box_a.center.y - box_b.center.y) < (box_a.height + box_b.height) / 2;
            if(cond_a && cond_b) 
            return true;

            return false;
        }

        bool CheckCircle(Circle c1, Circle c2) {
            //조건 : 두 원의 중심 간 거리가 두 원의 반지름 합보다 작아야 함
            bool cond = Vector3.Distance(c1.center, c2.center) < c1.radius + c2.radius;

            if (cond) return false; 
            return true;
        }
        //목표까지 남은 거리가 일정 값 이하 = 한 프레임에 이동하는 거리보다 작을 때 충돌로 판정해야 함
        bool CheckCollision() {
            if (target == null) return false;

            float dist_per_frame = Time.deltaTime * speed;
            if (Vector3.Distance(this.transform.position, target.position) < dist_per_frame) {
                return true;
            }
            return false;
        }

        
    }
}