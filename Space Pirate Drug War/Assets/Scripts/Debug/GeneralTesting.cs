using UnityEngine;
using UnityEngine.EventSystems;

namespace SPDW.Testing
{
    public class GeneralTesting : MonoBehaviour
    {
    public GameObject firstButton;

    void Start()
    {
        EventSystem.current.SetSelectedGameObject(firstButton);
    }
    }
}
