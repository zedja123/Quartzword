using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Personagem : MonoBehaviour
{
    [SerializeField] private Image barraVida;
    [SerializeField] private Image barraMana;

    private float vidaAtual;
    private float manaAtual;
    [SerializeField] private float vidaMaxima;
    [SerializeField] private float manaMaxima;

    private void Awake()
    {
        vidaAtual = vidaMaxima;
        manaAtual = manaMaxima;
    }

    public void RecebeDano(float _dano)
    {
        vidaAtual = Mathf.Max(vidaAtual - _dano, 0);
        AtualizaVida();

        if (vidaAtual == 0) Morte();
    }

    public void RecebeCura(float _cura)
    {
        vidaAtual = Mathf.Min(vidaAtual + _cura, vidaMaxima);
        AtualizaVida();
    }

    public void RecebeMana(float _valor)
    {
        manaAtual = Mathf.Min(manaAtual + _valor, manaMaxima);
        AtualizaMana();
    }

    public void GastaMana(float _valor)
    {
        manaAtual = Mathf.Max(manaAtual - _valor, 0);
        AtualizaMana();
    }

    void AtualizaVida()
    {
        barraVida.fillAmount = vidaAtual / vidaMaxima;
    }

    void AtualizaMana()
    {
        barraMana.fillAmount = manaAtual / manaMaxima;
    }

    public virtual void Morte()
    {

    }
}
