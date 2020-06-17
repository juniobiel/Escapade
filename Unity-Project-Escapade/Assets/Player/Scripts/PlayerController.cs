﻿using System.Collections;
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

    [Header("Itens e objetos")]
    //itens e objetos
    public GameObject lanterna;
    public GameObject Luz;
    public GameObject lanternaFake;
    public bool luzOff;
    public int bateria;
    public int tempoBateria;
    public float pecas;
    public bool pegouLanterna;
    public bool portaAberta;
    public bool geradorLigado;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        pecas = 0;
        tempoBateria = 0;
        bateria = 0;
        luzOff = false;
        pegouLanterna = false;
        portaAberta = false;
        geradorLigado = false;
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

        if(pegouLanterna == true)
        {
            lanterna.SetActive(true);
            lanternaFake.SetActive(false);
        }

        if(Input.GetKeyDown(KeyCode.F))
        {
            if (bateria <= 0 && tempoBateria <= 0)
            {
                Debug.Log("Sem bateria!");
            }
            else
            {
                if (pegouLanterna == true)
                {
                    if (luzOff == true)
                    {
                        Luz.SetActive(true);
                        luzOff = false;
                    }
                    else
                    {
                        Luz.SetActive(false);
                        luzOff = true;
                    }
                }
            }
            
        }

        if(luzOff == false)
        {
            if(bateria <= 0 && tempoBateria <= 0)
            {
                Luz.SetActive(false);
                luzOff = true;
            }
            else
            {
                tempoBateria--;

                if (tempoBateria <= 0)
                {
                    bateria--;
                }
            }           
        }
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

    private void OnTriggerStay(Collider other)
    {

        switch (other.gameObject.tag)
        {
            case "PortaSala":
                if (Input.GetKeyDown(KeyCode.E))
                {
                    Debug.Log("Porta Aberta");
                    other.transform.rotation = Quaternion.Slerp(Quaternion.Euler(0, -104, 0), transform.rotation,  Time.deltaTime);             
                }
                break;

            case "PortaSala2":
                if (Input.GetKeyDown(KeyCode.E))
                {
                    Debug.Log("Porta Aberta");
                    other.transform.rotation = Quaternion.Slerp(Quaternion.Euler(0, 104, 0), transform.rotation, Time.deltaTime);
                }
                break;

            case "Peca":

                pecas++;
                Debug.Log("Nova peça do gerador encontrada!");
                this.gameObject.SetActive(false);

                break;

            case "Gerador":

                if (pecas >= 5)
                {
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        Debug.Log("Energia Ligada!");
                        geradorLigado = true;
                        portaAberta = true;
                    }
                }
                else
                {
                    Debug.Log("São necessárias 5 peças, você possui " + pecas);
                }

                break;

            case "Porta":
                if (Input.GetKeyDown(KeyCode.E))
                {
                    if (portaAberta == true)
                    {
                        Debug.Log("Porta Aberta!");
                    }
                    else
                    {
                        Debug.Log("Ligue a energia primeiro!");
                    }

                }

                break;

            case "LanterFake":
                if (Input.GetKeyDown(KeyCode.E))
                {
                    pegouLanterna = true;
                    Debug.Log("Pegou a lanterna!");
                }

                break;

            case "Bateria":
                bateria++;
                tempoBateria += 500;
                Debug.Log("Você pegou uma bateria!");
                other.gameObject.SetActive(false);

                break;
        }
        
    }
}
