using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <example>Local</example>
public class Baralho : Local
{

    public BancoDeCartas bc;

    void Start()
    {
        //instancia O baralho

        Cartas = new List<GameObject>();

        /// de i 0 ate a quantidade de cartas<Tipo>CardTypes</Tipo> *10 
        /// tendo 3 cartas no banco inicialmente deve gerar 30 cartas
        for (int i = 0; i < bc.CartasDisponiveis.Count * 10; i++)
        {
            //cria cartas 10 de cada Cardtype por vez
            /// 30 cards total
            /// 0 - 9  / 10 =0
            /// 10 - 19  / 10 =1
            /// 20 - 29  / 10 =2
            Cartas.Add(Instantiate(bc.CartasDisponiveis[i/10], transform.position, transform.rotation));

            Cartas[i].GetComponent<Carta>().LocalQueCartaEsta = this;
        }
        Embaralhador();
    }
    //Embaralha as cartas trocando duas cartas de posição
    // by :GamesIndie - Tutoriais de Unity & Programação - Youtube channnel
    [ContextMenu("embaralhar")]
    public void Embaralhador()
    {
        for(int i=0; i<Cartas.Count; i++)
        {
            GameObject cartaAtual = Cartas[i];
            int indexRandom = Random.Range(0, Cartas.Count);
            Cartas[i] = Cartas[indexRandom];
            Cartas[indexRandom] = cartaAtual;
        }
    }

    // Update is called once per frame
    void Update()
    {
        /// Mover Cartas
        /// empilha cartas para cima (-transform.forward) 
        /// com a distancia(bc.CartasDisponiveis[0].transform.lossyScale.z) entre elas

        DirecaoQ_a_CartaVai = -transform.forward * bc.CartasDisponiveis[0].transform.lossyScale.z;
        //mover para mao
        //DirecaoQ_a_CartaVai = -transform.right * bc.CartasDisponiveis[0].transform.lossyScale.x;
    }

    public void removeCard()
    {//remove  uma carta da lista de Cartas deste <link>Local</link>
        Cartas.Remove(gameObject);
    }

  
}
