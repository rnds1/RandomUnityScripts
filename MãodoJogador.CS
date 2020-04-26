using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <example>Local</example>
public class maoJogador : Local 
{
    
    public BancoDeCartas bc;
    public Baralho baralho;
    void Start()
    {
        baralho = GameObject.Find("Baralho").GetComponent<Baralho>();
    }

    // Update is called once per frame
    void Update()
    {
        

        this.DirecaoQ_a_CartaVai = -transform.right * bc.CartasDisponiveis[0].transform.lossyScale.x;

        for(int i = 0; i < this.Cartas.Count; i++)
        {
            if (this.Cartas[i].GetComponent<Carta>().LocalQueCartaEsta != this)
                this.Cartas.Remove(Cartas[i]);

        } 
       
        if(this.Cartas.Count < 3)
        {
            Pegar();
        }



    }
    [ContextMenu("PegarCarta")]
    public void Pegar()
    {   ///<example>
        /// adiciona ultima carta do baralho na mão o jogador
        /// Remove ultima carta do baralho
        /// Atualiza <link>Local</link>da carta
        /// Atualiza rotação da carta
        /// </example>


        this.Cartas.Add(baralho.Cartas[baralho.Cartas.Count - 1]);
                baralho.Cartas.RemoveAt(baralho.Cartas.Count - 1);
        foreach (GameObject t in this.Cartas )
        {
            t.gameObject.GetComponent<Carta>().LocalQueCartaEsta = this;
            t.gameObject.GetComponent<Carta>().transform.rotation = this.transform.rotation;
        }
       
       
    }
    [ContextMenu("use")]
    public void Usar()
    {
        ///<example> Exemplo de uso de carta 
        ///Move a Carta para o Rematerializar
        /// </example>
        this.Cartas[0].GetComponent<Carta>().LocalQueCartaEsta = GameObject.Find("Rematerializar").GetComponent<Rematerializar>();
        
    }
}
