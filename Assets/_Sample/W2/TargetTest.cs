using UnityEngine;

namespace Sample {
    public class TargetTest : MonoBehaviour {
        int val_a = 10;
        public int val_b = 20;

        public int Get_A() { return val_a; }

        public void Set_A(int n) { n = val_a; }
    }


}