using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PauseMenu : MonoBehaviour
{
    [SerializeField] Transform PausaMenu;



    [SerializeField] GameObject Pausado;

    [SerializeField] GameObject Continuar;

   


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (PausaMenu.gameObject.activeSelf)
            {
                PausaMenu.gameObject.SetActive(false);
                Pausado.SetActive(false);
              
                Continuar.SetActive(false);

                Time.timeScale = 1;


            }
            else
            {

                Time.timeScale = 0;
               
                PausaMenu.gameObject.SetActive(true);
                Pausado.SetActive(true);

                Continuar.SetActive(true);

            }


        }
    }

    public void ContinuarGame()
    {
        if (PausaMenu.gameObject.activeSelf)
        {
            Time.timeScale = 1;
          
            PausaMenu.gameObject.SetActive(false);
            Pausado.SetActive(false);






        }
    }

    public void FecharOpçao()
    {

        PausaMenu.gameObject.SetActive(true);
        Time.timeScale = 0;

    }


    public void VoltarProMenu()
    {


        SceneManager.LoadScene("MainMenu");

    }
}
