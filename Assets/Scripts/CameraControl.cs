using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    float sens = 20f;
    [SerializeField]
    private Transform player;
    private Vector3 offset;
    private JCamera jCamera;
    private Vector2 worldDelta;
    private Vector3 moveVector;
    Quaternion originalRot;

   
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        jCamera = GameObject.FindGameObjectWithTag("CJoystick").GetComponent<JCamera>();
        transform.position = new Vector3(player.position.x, player.position.y+4, player.position.z-5);
        Quaternion quaternion = Quaternion.Euler(25, 0, 0);
        transform.rotation = quaternion;
        offset = player.transform.position - transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = player.transform.position-offset;

        if (jCamera.GetCheckJoystick())
        {
            worldDelta = jCamera.GetWorldDelta();
            moveVector = new Vector3(0, -worldDelta.x, 0);
            transform.RotateAround(player.transform.position, moveVector, sens * Time.deltaTime);
            offset = player.transform.position - transform.position;
        }
    }

}
