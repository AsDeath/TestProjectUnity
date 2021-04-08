using UnityEngine.EventSystems;
using UnityEngine;

public class ButtonJump : MonoBehaviour, IPointerClickHandler
{
    private bool jump = false;
    public virtual void OnPointerClick(PointerEventData red)
    {
        if (!jump) jump = true;
    }

    public bool GetButJump(){
        return jump;
    }

    public void SetButJump(bool b){
        jump = b;
    }
}
