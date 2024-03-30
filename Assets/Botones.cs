using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Botones : MonoBehaviour
{
    [SerializeField] GameObject ElPanel;
    [SerializeField] Nave Nivel1;
    [SerializeField] Nave Nivel2;
    [SerializeField] Nave Nivel3;
    [SerializeField] Nave NaveElegida;
    private void Start()
    {
        seleccionarNave(Nivel2);
    }
    public void Jugar()
    {
        SceneManager.LoadScene(0);
    }

    public void ElegirPersonaje()
    {
        ElPanel.SetActive(true);
    }

    public void Nave1()
    {
        seleccionarNave(Nivel1);
        ElPanel.SetActive(false);
    }
    public void Nave2()
    {
        seleccionarNave(Nivel2);
        ElPanel.SetActive(false);
    }
    public void Nave3()
    {
        seleccionarNave(Nivel3);
        ElPanel.SetActive(false);
    }

    void seleccionarNave(Nave laNave)
    {
        NaveElegida.Imagen = laNave.Imagen;
        NaveElegida.vida= laNave.vida;
        NaveElegida.velocidadHorizontal = laNave.velocidadHorizontal;
        NaveElegida.velocidadVertical = laNave.velocidadVertical;
    }

}
