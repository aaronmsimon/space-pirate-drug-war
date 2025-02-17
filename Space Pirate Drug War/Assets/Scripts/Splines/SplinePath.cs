using UnityEngine;
using UnityEngine.Splines;

namespace SPDW.Splines
{
    public class SplinePath : MonoBehaviour
    {
        [SerializeField] SplineContainer splineContainer;

        public SplineContainer SplineContainer => splineContainer;
    }
}
