using UnityEngine;

namespace SPDW.UI
{
    public class TabletArrow : MonoBehaviour
    {
        [SerializeField] private int itemCount;
        [SerializeField] private Vector3 firstItemPos;
        [SerializeField] private float itemSpacing;

        private int selectedItem = 0;

        public void ChangeItem(int dir) {
            selectedItem = (selectedItem - dir + itemCount) % itemCount;
            MoveArrow();
        }

        private void MoveArrow() {
            transform.localPosition = firstItemPos + itemSpacing * selectedItem * Vector3.down;
        }

        // ---- PROPERTIES ----
        public int ItemCount => itemCount;
    }
}
