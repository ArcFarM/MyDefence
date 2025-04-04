using Sample;
using UnityEngine;

namespace Sameple {
    public class PlayerTest : MonoBehaviour {
        
        void Start() {
            var singletonA = Singleton.GetSingleton;
            var singletonB = Singleton.GetSingleton;

            if(singletonA == singletonB) {
                if (singletonB != null)
                    Debug.Log("singletonB");

                else Debug.Log("singletonA");
            }

            Debug.Log(singletonB.Get_number());
            Debug.Log(Singleton.Get_static_number());
        }

        // Update is called once per frame
        void Update() {

        }
    }

}
