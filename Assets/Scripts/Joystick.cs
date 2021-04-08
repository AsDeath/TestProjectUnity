using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Joystick : MonoBehaviour, IPointerUpHandler, IPointerDownHandler, IDragHandler
{
    private Image joystickBG;
    [SerializeField]
    private Image joystick;
    private Vector2 inputVector;


    void Start()
    {
        joystickBG = GetComponent<Image>();
        joystick = transform.GetChild(0).GetComponent<Image>();
    }

    public virtual void OnPointerDown(PointerEventData red)
    {
        OnDrag(red);
    }

    public virtual void OnPointerUp(PointerEventData red)
    {
        inputVector = Vector2.zero;
        joystick.rectTransform.anchoredPosition = Vector2.zero;
    }

    public virtual void OnDrag(PointerEventData red)
    {
        Vector2 pos;
        if(RectTransformUtility.ScreenPointToLocalPointInRectangle(joystickBG.rectTransform, red.position, red.pressEventCamera, out pos)){
            pos.x = (pos.x/joystickBG.rectTransform.sizeDelta.x);
            pos.y = (pos.y/joystickBG.rectTransform.sizeDelta.y);

            inputVector = (pos.magnitude > 0.5f) ? pos.normalized : pos;
            joystick.rectTransform.anchoredPosition = new Vector2(inputVector.x*(joystickBG.rectTransform.sizeDelta.x/2), inputVector.y*(joystickBG.rectTransform.sizeDelta.y/2));
        }
    }

    public float Horizontal(){
        if(inputVector.x != 0) return inputVector.x;
        else return Input.GetAxis("Horizontal");
    }

    public float Vertical(){
        if(inputVector.y != 0) return inputVector.y;
        else return Input.GetAxis("Vertical");  
    }
}