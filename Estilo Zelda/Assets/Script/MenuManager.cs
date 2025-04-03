using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private string NomeDaFase;
    [SerializeField] private GameObject painelOpçao;
    [SerializeField] private GameObject painelMenuPrincipal;
    [SerializeField] private GameObject boss;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void Jogar()
    {
        SceneManager.LoadScene(NomeDaFase);
        Time.timeScale = 1f;

    }
    public void AbrirOpçao()
    {
        painelOpçao.SetActive(true);
        painelMenuPrincipal.SetActive(false);
        boss.SetActive(false);
    }
    public void FecharOpçao()
    {
        painelOpçao.SetActive(false);
        painelMenuPrincipal.SetActive(true);
        boss.SetActive(true);
    }
    

    public void Sair()
    {
        Application.Quit();
    }
}
