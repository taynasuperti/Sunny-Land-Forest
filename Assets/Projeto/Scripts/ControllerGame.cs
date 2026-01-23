using UnityEngine;
using TMPro;
using UnityEngine.UI;

// é nesse script que vamos controlar o fluxo do jogo
public class ControllerGame : MonoBehaviour
{
    private int score;
    public TMP_Text txtScore;

    //guarda o prefab de explosão
    public GameObject hitprefab;

    //para guardar o hud das vidas
    public Sprite[] imagensVida;
    public Image barraVida;

    //para controlar o audios do jogo
    public AudioSource fxGame;
    public AudioClip fxCenouraColetada;
    public AudioClip fxPlayerDie;

    //controla o audio de morte do inimigo
    public AudioClip fxExplosao;


    public void Pontuacao(int qtdPontos)
    {
        score += qtdPontos;
        txtScore.text = score.ToString();

        //tocar o som de cenoura coletada
        fxGame.PlayOneShot(fxCenouraColetada);
    }

    public void BarraVida(int healthvida)
    {
        barraVida.sprite = imagensVida[healthvida];
    }
}
