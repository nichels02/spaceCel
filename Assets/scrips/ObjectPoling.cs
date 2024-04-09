using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPoling : MonoBehaviour
{
    [SerializeField] GameObject Objeto;
    List<GameObject> ListaDeObjetos = new List<GameObject>();
    int CantidadApagados;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    


    public GameObject NuevoObjeto(Vector3 laPosicion)
    {
        GameObject ElObjeto = null;
        if (CantidadApagados == 0)
        {
            ElObjeto = Instantiate(Objeto, laPosicion, Quaternion.identity);
            ElObjeto.GetComponent<ObjetosRepetibles>().Lalista = this;
            ListaDeObjetos.Add(ElObjeto);
            return ElObjeto;
        }
        else
        {
            for (int i = 0; i < ListaDeObjetos.Count; i++)
            {
                if (!ListaDeObjetos[i].activeSelf)
                {
                    ElObjeto = ListaDeObjetos[i];
                    /*
                    ListaDeObjetos[i].transform.position = laPosicion;
                    ListaDeObjetos[i].gameObject.SetActive(true);
                    */
                    CantidadApagados--;
                    break;
                }
            }
            ElObjeto.transform.position = laPosicion;
            ElObjeto.gameObject.SetActive(true);
            return ElObjeto;

        }
        
    }


    public void SeDesactivo()
    {
        CantidadApagados++;
    }
}
