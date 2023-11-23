using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movimentoplayer : MonoBehaviour
{
    public float velocidade = 1.5f; // Velocidade de movimento do personagem
    public float velocidadeRotacao = 100.0f; // Velocidade de rotação do personagem
    private Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update é chamado uma vez por frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.forward * Time.deltaTime * velocidade);
            anim.SetBool("avancar", true);
            anim.SetBool("voltar", false);
        }
        if(Input.GetKeyUp(KeyCode.W))
        {
            anim.SetBool("avancar", false);
        }


        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.back * Time.deltaTime * velocidade);
            anim.SetBool("avancar", false);
            anim.SetBool("voltar", true);
        }
        if(Input.GetKeyUp(KeyCode.S))
        {
            anim.SetBool("voltar", false);
        }



        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(Vector3.up, -velocidadeRotacao * Time.deltaTime);
        }



        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(Vector3.up, velocidadeRotacao * Time.deltaTime);
        }
    }
}
