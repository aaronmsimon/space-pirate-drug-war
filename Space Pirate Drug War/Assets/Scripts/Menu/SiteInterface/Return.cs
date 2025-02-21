using UnityEngine;
using RoboRyanTron.Unite2017.Events;
using SPDW.Actors;

namespace SPDW.Menu
{
    public class Return : MonoBehaviour, IMenuItemSelected
    {
        [SerializeField] private GameEvent travelToStarSystemGameEvent;

        public void OnMenuItemSelected(Player player) {
            player.StateMachine.ChangeState(player.StarSystemState);
            travelToStarSystemGameEvent.Raise();

        }
    }
}