using UnityEngine;


namespace Sample {
    public class Singleton : MonoBehaviour {
        private void Awake() {
            if(instance != null) {
                Destroy(gameObject);
                return;
            }
            instance = this;

            DontDestroyOnLoad(gameObject);
        }

        static Singleton instance;

        int number = 1234;

        public int Get_number() {
            return number;
        }

        public static int Get_static_number() {
            return 0;
        }

        public static Singleton GetSingleton {
            get {
                if(instance == null) instance = new Singleton();
                return instance;
            }
        }

        
    }

}
