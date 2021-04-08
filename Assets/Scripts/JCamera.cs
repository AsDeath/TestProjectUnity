using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class JCamera : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
{
    private Vector2 worldDelta;
    private Vector2 worldStartPoint;
    private Image joystick2;
    private RectTransform rectTransform;

    bool checkJoystick = false;
    void Start()
    {
        joystick2 = GetComponent<Image>();
        rectTransform = GetComponent<RectTransform>();
        rectTransform.sizeDelta = new Vector2(Screen.width, Screen.height);
        //rectTransform.transform.position = new Vector2(Screen.width, Screen.height / 2);
    }

    public virtual void OnPointerDown(PointerEventData red)
    {
        RectTransformUtility.ScreenPointToLocalPointInRectangle(joystick2.rectTransform, red.position, red.pressEventCamera, out worldStartPoint);
        checkJoystick = true;
    }

    public virtual void OnPointerUp(PointerEventData red)
    {
        checkJoystick = false;
    }

    public virtual void OnDrag(PointerEventData red)
    {
        RectTransformUtility.ScreenPointToLocalPointInRectangle(joystick2.rectTransform, red.position, red.pressEventCamera, out worldDelta);
        worldDelta = worldStartPoint - worldDelta;
    }

    public Vector2 GetWorldDelta()
    {
        return worldDelta;
    }
    public bool GetCheckJoystick()
    {
        return checkJoystick;
    }
}
