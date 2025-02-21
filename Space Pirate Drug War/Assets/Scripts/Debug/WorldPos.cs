using UnityEngine;

namespace SPDW.Testing
{
    public class WorldPos : MonoBehaviour
    {
        [SerializeField] private Camera cam;

        private void Start() {
            Vector3 pos = cam.transform.position - cam.ScreenToWorldPoint(transform.position);
            Debug.Log($"{gameObject.name} is at screen pos {transform.position} which is world pos {pos}");
        }
    }
}
