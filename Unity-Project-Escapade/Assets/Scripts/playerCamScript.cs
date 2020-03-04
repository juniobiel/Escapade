using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerCamScript : MonoBehaviour
{
    float sensibilidade;
    float anguloY;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MovimentarCamera();
        
    }

    void MovimentarCamera()
    {
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        float movimentacaoY;
        //define a sensibilidade de movimentacao
        sensibilidade = 60f;
        //a movimentacao no eixo Y
        movimentacaoY = RotacaoY(mouseY);
        RotacaoX(mouseX, sensibilidade);
        //Limita a camera
        LimitarCamera(movimentacaoY);
        
        if (anguloY <= 20f || anguloY >= 270f)
            transform.Rotate(movimentacaoY, 0f, 0f);
    }

    float RotacaoY(float mouseY)
    {
        return mouseY * sensibilidade * Time.deltaTime;
    }

    void RotacaoX(float mouseX, float sensibilidade)
    {
        transform.Rotate(0f, mouseX * sensibilidade * Time.deltaTime, 0f, Space.World);
    }

    void LimitarCamera(float movimentacaoY)
    {
        anguloY = transform.eulerAngles.x + movimentacaoY;
    }
}
