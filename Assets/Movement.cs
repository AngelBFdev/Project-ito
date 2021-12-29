using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    bool Izq, Der, Arr, Aba = false;
    public float speed = .5f;
    public GameObject MensajeFinal;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Izq)
        {
            if (!GetComponent<SpriteRenderer>().flipX)
            {
                GetComponent<SpriteRenderer>().flipX = true;
            }
            transform.Translate(-speed, 0, 0);
        }
        else if (Der)
        {
            if (GetComponent<SpriteRenderer>().flipX)
            {
                GetComponent<SpriteRenderer>().flipX = false;
            }
            transform.Translate(speed, 0, 0);
        }
        else if (Arr)
        {
            transform.Translate(0, speed, 0);
        }
        else if (Aba)
        {
            transform.Translate(0, -speed, 0);
        }

        if (Aba || Arr || Izq || Der)
        {
            GetComponent<Animator>().SetBool("Correr", true);
        }
    }

    public void Izquierda()
    {
        Izq = true;
    }
    public void Derecha()
    {
        Der = true;
    }
    public void Arriba()
    {
        Arr = true;
    }
    public void Abajo()
    {
        Aba = true;
    }
    public void Nada()
    {
        Izq = false;
        Der = false;
        Arr = false;
        Aba = false;
        GetComponent<Animator>().SetBool("Correr", false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Finish")
        {
            Destroy(gameObject);
            TextoFinal();
        }
    }

    public void TextoFinal()
    {

        GameObject texto = Instantiate(MensajeFinal);
        texto.transform.SetParent(GameObject.FindWithTag("Finish").transform);
    }
}