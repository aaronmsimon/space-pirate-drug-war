using UnityEngine;

namespace SPDW.Effects
{
    public class ChangeRimPower : MonoBehaviour
    {
        [SerializeField] private float newAmount;

        private MeshRenderer meshRenderer;
        private Material material;
        private float originalAmount;

        private void Awake() {
            meshRenderer = GetComponent<MeshRenderer>();
            if (meshRenderer != null) {
                material = meshRenderer.material;
                if (material.HasFloat("_RimPower")) {
                    originalAmount = material.GetFloat("_RimPower");
                }
            }
        }

        public void SetToNewAmount() {
            if (material != null & material.HasFloat("_RimPower")) {
                material.SetFloat("_RimPower", newAmount);
            }
        }

        public void ReturnToOriginal() {
            if (material != null & material.HasFloat("_RimPower")) {
                material.SetFloat("_RimPower", originalAmount);                
            }
        }
    }
}
