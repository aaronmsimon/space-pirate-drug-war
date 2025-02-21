using System.Collections.Generic;
using UnityEngine;
using TMPro;
using SPDW.Actors;

namespace SPDW.Menu
{
    public class MenuNavigation : MonoBehaviour
    {
        [Header("Menu Items")]
        [SerializeField] private List<TMP_Text> menuItems;
        [SerializeField] private Color selectedColor = Color.yellow;
        [SerializeField] private Color unselectedColor = Color.white;
        
        private int selectedIndex = 0;
        private Player player;

        private void Start()
        {
            player = FindFirstObjectByType<Player>();
            UpdateMenuSelection();
        }

        private void UpdateMenuSelection()
        {
            for (int i = 0; i < menuItems.Count; i++)
            {
                menuItems[i].color = (i == selectedIndex) ? selectedColor : unselectedColor;
            }
        }

        public void Navigate(int direction)
        {
            selectedIndex += direction;
            if (selectedIndex < 0) selectedIndex = menuItems.Count - 1;
            if (selectedIndex >= menuItems.Count) selectedIndex = 0;
            UpdateMenuSelection();
        }

        public void SelectCurrentItem()
        {
            menuItems[selectedIndex].GetComponent<IMenuItemSelected>().OnMenuItemSelected(player);
        }
    }
}
