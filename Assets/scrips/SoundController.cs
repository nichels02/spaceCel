using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SoundController : MonoBehaviour
{
    public static SoundController instance { get; private set; }
    AudioSource ReproductorMusica;
    [SerializeField] AudioSource[] ListaAudioSource = new AudioSource[1];
    [SerializeField] AudioClip[] Musica = new AudioClip[1];

    public virtual void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(gameObject);
        }
        ReproductorMusica = GetComponent<AudioSource>();
    }



    // Start is called before the first frame update
    void Start()
    {
        ReproductorMusica.loop = true;
        ReproductorMusica.clip = Musica[0];
        ReproductorMusica.Play();
    }


    public void CambiarMusica(AudioClip ElAudio)
    {
        int x = BuscarReproductorVacio();
        ListaAudioSource[x].clip = ElAudio;
        ListaAudioSource[x].Play();
    }

    public void CambiarMusica(int audio)
    {
        int x = BuscarReproductorVacio();
        ListaAudioSource[x].clip = Musica[audio];
        ListaAudioSource[x].Play();
    }

    public int BuscarReproductorVacio()
    {
        int index = ListaAudioSource.Length;
        for (int i=0; i<ListaAudioSource.Length; i++) 
        {
            if (!ListaAudioSource[i].isPlaying)
            {
                return i;
            }
        }
        return index;
        
    }

}
