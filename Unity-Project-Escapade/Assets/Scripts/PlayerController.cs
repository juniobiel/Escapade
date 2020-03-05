using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public bool enableMouse;
    [Header("Configs do Player")]
    public float speed;
    public float RunSpeed;
    public float sensibility;

    [Header("Imports")]
    public Camera cam;

    //Privates
    private Rigidbody rb;
    private float realSpeed;
    private Vector3 velocity;
    private Vector3 rotation;
    private Vector3 camRotation;
    private float rotCam;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        #region Movimento
        //Captura as teclas de movimento a e d ou → e ←
        float _xMov = Input.GetAxisRaw("Horizontal");
        //Caputra as teclas de movimento w e s ou ↑ e ↓
        float _yMov = Input.GetAxisRaw("Vertical");
        //define quando correr
        if (Input.GetButton("Run") == true && _xMov == 0 && _yMov == 1)
            realSpeed = RunSpeed;
        else
            realSpeed = speed;
        //Constrói o vetor de movimento nos eixos
        Vector3 _MoveHorizontal = transform.right * _xMov;
        Vector3 _MoveVertical = transform.forward * _yMov;
        //aplica o movimento
        velocity = (_MoveHorizontal + _MoveVertical).normalized * realSpeed;

        #endregion

        #region Rotation
        //Captura as posicoes do mouse
        float _yMouse = Input.GetAxisRaw("Mouse X");
        //define a rotação
        rotation = new Vector3(0, _yMouse, 0) * sensibility;

        float _xMouse = Input.GetAxisRaw("Mouse Y");
        camRotation = new Vector3(_xMouse, 0, 0) * sensibility;
        #endregion

        #region enableMouse
        if (enableMouse)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }

        #endregion
    }

    private void FixedUpdate()
    {
        if (enableMouse)
        {
            Movimenta();
            Rotation();
        }
            
    }
    //define a movimentação do personagem
    void Movimenta()
    {
        if (velocity != Vector3.zero)
            rb.MovePosition(rb.position + velocity * Time.deltaTime);
    }
    //faz a rotação da camera
    void Rotation()
    {
        rb.MoveRotation(rb.rotation * Quaternion.Euler(rotation));

        if(cam != null)
        {
            rotCam += camRotation.x;
            rotCam = Mathf.Clamp(rotCam, -80, 80);

            cam.transform.localEulerAngles = new Vector3(-rotCam, 0, 0);
        }
    }
}
