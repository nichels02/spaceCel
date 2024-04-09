using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NaveAlienigena : ObjetosRepetibles
{
    // Start is called before the first frame update
    [SerializeField] float posicionMax;
    [SerializeField] float posicionMin;
    [SerializeField] float TiempoParaCambiar;
    [SerializeField] float Tiempo;
    [SerializeField] Vector3 Direccion;
    public bool ArribaOAbajo;
    public float velocidad;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Tiempo += Time.deltaTime;
        if (Tiempo > TiempoParaCambiar || (transform.position.y > posicionMax && !ArribaOAbajo) || (transform.position.y < posicionMin && ArribaOAbajo))
        {
            Tiempo = 0;
            TiempoParaCambiar = Random.RandomRange(2, 7);
            Direccion = ArribaOAbajo ? Vector2.left + Vector2.up : Vector2.left + Vector2.down;
            ArribaOAbajo = !ArribaOAbajo;
        }
        else if(transform.position.x < limite)
        {
            Lalista.SeDesactivo();
            gameObject.SetActive(false);
        }
        else
        {
            transform.position += Direccion.normalized * velocidad * Time.deltaTime;
        }
    }


}
