using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Jugador : MonoBehaviour
{
    public Nave LaNave;
    SpriteRenderer MySprite;
    [SerializeField] float vida;
    [SerializeField] float velocidadHorizontal;
    [SerializeField] float velocidadVertical;
    [SerializeField] float alturaMax;
    [SerializeField] float alturaMin;
    float SubirOBajar;
    bool coliciono;
    bool Murio;
    float tiempo;
    [SerializeField] float tiempoParaVolverNormal;
    Color Colorguardado;
    [SerializeField] Color ColorDeModificacion;
    // Start is called before the first frame update
    void Start()
    {

        MySprite = GetComponent<SpriteRenderer>();
        Colorguardado = MySprite.color;
        vida = LaNave.vida;
        ControladorTiempo.instance.VelocidadDeLaNave = LaNave.velocidadHorizontal;
        for(int i = 0;i< ControladorTiempo.instance.Mapa.Length; i++)
        {
            ControladorTiempo.instance.Mapa[i].DarUnValorVelocidad();
        }
        velocidadVertical = LaNave.velocidadVertical;
        MySprite.sprite = LaNave.Imagen;
        ControladorTiempo.instance.LaUi.actualizarVida(vida);
    }

    // Update is called once per frame
    void Update()
    {
        if (SubirOBajar > 0 && transform.position.y < alturaMax && !Murio)
        {
            transform.position += Vector3.up * velocidadVertical * Time.deltaTime;
        }
        else if (SubirOBajar < 0 && transform.position.y > alturaMin && !Murio)
        {
            transform.position += Vector3.down * velocidadVertical * Time.deltaTime;
        }
        if (coliciono && tiempo < tiempoParaVolverNormal)
        {
            tiempo += Time.deltaTime;
            MySprite.color = ColorDeModificacion;
        }
        else
        {
            coliciono = false;
            MySprite.color = Colorguardado;
        }
    }

    public void ElevarAltura(InputAction.CallbackContext value) 
    {
        SubirOBajar = value.ReadValue<float>();

        

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        print("coliciono");
        if (collision.tag == "Metiorito" && coliciono == false)
        {
            print("coliciono2");
            vida -= 1;
            coliciono = true;
            tiempo = 0;
            ControladorTiempo.instance.LaUi.actualizarVida(vida);
            if (vida == 0)
            {
                ControladorTiempo.instance.SeMurio = true;
                Murio = true;
                ControladorTiempo.instance.LaUi.Moriste();
                //Metodo del tiempo para detenerlo y aparecer el panel
            }
        }
    }

}
