using UnityEngine;

namespace MyDefense {
    public class Tile : MonoBehaviour {

        //구분용 머터리얼
        public Material defaultMat;
        public Material filledMat;
        Renderer renderer;

        

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start() {
            renderer = GetComponent<Renderer>();
            defaultMat = renderer.material;
        }

        // Update is called once per frame
        void Update() {

        }

        private void OnMouseEnter() {
            renderer.material = filledMat;
        }

        private void OnMouseExit() {
            renderer.material = defaultMat;
        }

        private void OnMouseDown() {
            Instantiate(BuildManager.Instance.towerPrefab, transform.position, Quaternion.identity);
        }
    }
}

