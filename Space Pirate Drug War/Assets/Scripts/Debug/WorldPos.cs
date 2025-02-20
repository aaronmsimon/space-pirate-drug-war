using UnityEngine;

namespace SPDW.Testing
{
    public class WorldPos : MonoBehaviour
    {
        private void Start() {
            Debug.Log($"{gameObject.transform.position} is at screen pos {Camera.main.ScreenToWorldPoint(gameObject.transform.position)}");
        }
    }
}
