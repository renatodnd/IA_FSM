using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeradorFrutas : MonoBehaviour
{
    public float timer = 4f;

    float tempo;

    int gerador;

    public GameObject Abacate;
    public GameObject Banana;
    public GameObject Limao;
    public GameObject Pera;
    public GameObject Pessego;
    public GameObject Melancia;

    Vector3 posicao;

    // Update is called once per frame
    void Update()
    {
        tempo = Time.deltaTime;
        timer -= tempo;
        if (timer <= 0f)
        {
            timer = 4f;
            // Gerador Pocicoes
            posicao.x = Random.Range(-25f, 25f);
            posicao.y = 2f;
            posicao.z = Random.Range(-48f, 48f);
            // Escolhe frutas
            gerador = Random.Range(0, 6);
            switch (gerador)
            {
                case 0:
                    Instantiate(Abacate, posicao, Quaternion.identity);
                    break;
                case 1:
                    Instantiate(Banana, posicao, Quaternion.identity);
                    break;
                case 2:
                    Instantiate(Limao, posicao, Quaternion.identity);
                    break;
                case 3:
                    Instantiate(Pera, posicao, Quaternion.identity);
                    break;
                case 4:
                    Instantiate(Pessego, posicao, Quaternion.identity);
                    break;
                case 5:
                    Instantiate(Melancia, posicao, Quaternion.identity);
                    break;
                default:
                    print("Erro");
                    break;
            }
        }
    }
}
