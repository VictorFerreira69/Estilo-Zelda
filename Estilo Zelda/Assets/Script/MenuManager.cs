using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField] string NomeDaFase;
    [SerializeField]  GameObject painelOpcao;
    [SerializeField]  GameObject painelMenuPrincipal;
    [SerializeField]  GameObject boss;
    [SerializeField]  GameObject ratoBaixo;
    [SerializeField] GameObject ratoEsquerda;
    [SerializeField] GameObject ratoDireita;
     [SerializeField] GameObject textoCriadores;


    public void Jogar()
    {
        SceneManager.LoadScene(NomeDaFase);
        Time.timeScale = 1f;

    }
    public void AbrirOpcao()
    {
        painelOpcao.SetActive(true);
        painelMenuPrincipal.SetActive(false);
        boss.SetActive(false);
        ratoBaixo.SetActive(false);
        ratoDireita.SetActive(false);
        ratoEsquerda.SetActive(false);
        textoCriadores.SetActive(false);
    }
    public void FecharOpcao()
    {
        painelOpcao.SetActive(false);
        painelMenuPrincipal.SetActive(true);
        boss.SetActive(true);
        ratoBaixo.SetActive(true);
        ratoDireita.SetActive(true);
        ratoEsquerda.SetActive(true);
        textoCriadores.SetActive(true);
    }
    

    public void Sair()
    {
        Application.Quit();
    }
}
