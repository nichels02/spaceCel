using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bala : ObjetosRepetibles
{
    [SerializeField] float Velocidad;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.right * Velocidad * Time.deltaTime;
        if (transform.position.x > limite)
        {
            Lalista.SeDesactivo();
            gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Metiorito")
        {
            collision.gameObject.SetActive(false);
            Lalista.SeDesactivo();
            gameObject.SetActive(false);
            SoundController.instance.CambiarMusica(3);
        }
    }
}
