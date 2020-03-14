using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuPrincipal : MonoBehaviour
{
    public Text startText;

    string texto1, texto2, texto3;

    float contador, contadorAnim;

    bool aumentar;
    // Start is called before the first frame update
    void Start()
    {
        //inicializacao de variaveis
        contador = 0;
        contadorAnim = 0;
        aumentar = false;
        //define texto
        texto3 = startText.text;
        texto2 = "Pressione para iniciar..";
        texto1 = "Pressione para iniciar.";
    }

    // Update is called once per frame
    void Update()
    {
        //contador para animar o texto
        contadorAnim += Time.deltaTime;
        //contador para liberar o start
        contador += Time.deltaTime;

        AnimarTexto();

        if (contador >= 1.5f && Input.anyKeyDown)
        {
            SceneManager.LoadScene("Escola", LoadSceneMode.Single);
        }
        
    }

    void AnimarTexto()
    {
        if (contadorAnim >= 0.5f)
        {            
            if (startText.text.Equals(texto3))
            {
                startText.text = texto2;
                aumentar = false;
            }
            else if (startText.text.Equals(texto2) && aumentar == false)
                startText.text = texto1;
            else if (startText.text.Equals(texto2) && aumentar == true)
                startText.text = texto3;
            else if (startText.text.Equals(texto1))
            {
                startText.text = texto2;
                aumentar = true;
            }
            contadorAnim -= contadorAnim;
        }
    }
}
