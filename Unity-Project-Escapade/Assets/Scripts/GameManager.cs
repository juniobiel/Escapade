using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    Dictionary<int, string> missoes;

    private void Start()
    {
        missoes = new Dictionary<int, string>();
        missoes.Add(1, "Encontre a chave para sair da sala de limpeza");

        Debug.Log(GetMission(1));
    }
    void LoadEscolaScene()
    {
        SceneManager.LoadScene("Escola", LoadSceneMode.Single);
    }

    public string GetMission(int id)
    {
        
        return missoes[id];
    }
}
