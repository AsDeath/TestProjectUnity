using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonAttack : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    CharacterMechanics character;
    Animator ch_animator;
    void Start(){
        character = GameObject.FindObjectOfType<CharacterMechanics>();
        ch_animator = character.GetComponent<Animator>();
    }
    public virtual void OnPointerDown(PointerEventData pointer){
        ch_animator.SetBool("Attack", true);
    }

    public virtual void OnPointerUp(PointerEventData pointer){
        ch_animator.SetBool("Attack", false);
    }

}
