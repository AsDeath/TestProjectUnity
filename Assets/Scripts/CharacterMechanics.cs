using UnityEngine;

public class CharacterMechanics : MonoBehaviour 
{
    public float speedMove = 3; //скорость персонажа
    public float jumpPower = 1; // сила прыжка

    //Параметры гемплея для персонажа
    private float gravityForce; //гравитация персонажа
    private Vector3 moveVector, globalMoveVector; //направление движения персонажа

    // ссылки на компоненты
    private CharacterController ch_controller;
    private Animator ch_animator;
    private Joystick joystick;
    private Transform main_camera;
    private ButtonJump buttonJump;
    private GrabWeapon grabWeapon;

    private void Start()
    {
        ch_controller = GetComponent<CharacterController>();
        ch_animator = GetComponent<Animator>();
        joystick = GameObject.FindGameObjectWithTag("Joystick").GetComponent<Joystick>();
        main_camera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Transform>();
        buttonJump = GameObject.FindObjectOfType<ButtonJump>();
        grabWeapon = GetComponent<GrabWeapon>();
    }

    private void Update()
    {
        ch_animator.SetInteger("TypeW", grabWeapon.GetWeaponType());
        CharacterMove();
        GamingGravity();
    }

    // Метод перемещения персонажа
    private void CharacterMove()
    {
        if(ch_controller.isGrounded){
            ch_animator.ResetTrigger("JumpTrigger");
            ch_animator.SetBool("Falling", false);
            
            // перемещение по поверхности
            moveVector = Vector3.zero;
            moveVector.x = joystick.Horizontal()*speedMove;
            moveVector.z = joystick.Vertical()*speedMove;

            if(moveVector.x!=0 || moveVector.z!=0){
                ch_animator.SetBool("Move", true);
            } else ch_animator.SetBool("Move", false);

            // Поворот в сторону движения
            if(moveVector != Vector3.zero){
                if(Vector3.Angle(transform.forward,main_camera.transform.forward)>1f){
                    Vector3 direct = Vector3.RotateTowards(transform.forward, main_camera.transform.forward, speedMove, 0.0f);
                    transform.rotation = Quaternion.LookRotation(direct);
                }
                if(Vector3.Angle(transform.forward,moveVector)>0.1f ){
                    Vector3 direct = Vector3.RotateTowards(transform.forward,transform.TransformDirection(moveVector),speedMove, 0.0f);
                    Quaternion q_rotation = Quaternion.LookRotation(direct);
                    q_rotation.x = 0;
                    q_rotation.z = 0;
                    transform.rotation = q_rotation;
                    moveVector.x = transform.forward.x;
                    moveVector.z = transform.forward.z;
                }
            }

            moveVector.y = gravityForce; // Управление jump (гравитацией), обязательно рассчитать после поворота 
            
        } else {
            if(gravityForce<-4f){
                ch_animator.SetBool("Falling", true);
            }
        }
        
        ch_controller.Move(moveVector*speedMove*Time.deltaTime);
    }

    private void GamingGravity(){
        if(!ch_controller.isGrounded){
            if (buttonJump.GetButJump()) buttonJump.SetButJump(false);//нажатие кнопки jump
            gravityForce -= 20f * Time.deltaTime;
        } else gravityForce = -1f;
        
        if((Input.GetKeyDown(KeyCode.Space) || buttonJump.GetButJump()) && ch_controller.isGrounded) {
            gravityForce = jumpPower;
            ch_animator.SetTrigger("JumpTrigger");
        }
    }
}