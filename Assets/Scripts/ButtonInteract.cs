
using UnityEngine;
using UnityEngine.EventSystems;
public class ButtonInteract : MonoBehaviour, IPointerClickHandler
{
    public static bool grab = false;
    public virtual void OnPointerClick(PointerEventData red)
    {
        grab = true;
    }

}
