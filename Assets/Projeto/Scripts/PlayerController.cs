using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
//cena
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour { 

    private Animator playerAnimator; 
    private Rigidbody2D playerRigidbody2d;
    private SpriteRenderer srPlayer;
    //variável para controlar se o player está invencível
    private bool playerInvencivel;

    public GameObject PlayerDie;

    //variável que checa se o player está no chão
    public Transform groundCheck;


    //variáveis de movimento
    public bool isGround = false; 
    public float speed = 5f; 
    public float touchRun = 0.0f; 
    public bool facingRigth = true;

    //variavel para a quantidade de vidas do player
    public int vidas = 3;

    //variaveis que controlam a cor do player ao levar dano
    public Color hitColor;
    public Color noHitColor;

    // variáveis para o pulo
    public bool jump = false;
    public int numberJumps = 0;
    public int maximoJump = 2;
    public float jumpForce = 8f;

    //essa variável faz a ligação com o script ControllerGame (pra coletar as cenouras)
    private ControllerGame _ControleGame;

    //para controlar o audios do jogo
    public AudioSource fxGame;
    public AudioClip fxPulo;

    //controla as particulas de pulo do personagem
    public ParticleSystem _poeira;

    private PlayerInputActions inputActions; 

    void Awake() { 
        inputActions = new PlayerInputActions(); 
    }
    
    void OnEnable() 
    { 
        inputActions.Player.Enable(); 
    }
    
    void OnDisable() 
    { 
        inputActions.Player.Disable(); 
    }
    
    void Start() 
    { 
        playerAnimator = GetComponent<Animator>(); 
        playerRigidbody2d = GetComponent<Rigidbody2D>(); 
        srPlayer = GetComponent<SpriteRenderer>();

        _ControleGame = FindFirstObjectByType(typeof(ControllerGame)) as ControllerGame; 
    } 
    
    void Update() 
    {
        isGround = Physics2D.Linecast(
    groundCheck.position + Vector3.up * 0.05f,
    groundCheck.position + Vector3.down * 0.05f,
    1 << LayerMask.NameToLayer("Ground"));

        playerAnimator.SetBool("isGrounded", isGround);

        Debug.Log(isGround.ToString());

        touchRun = inputActions.Player.Move.ReadValue<float>(); 
        //Debug.Log(touchRun);
        SetaMovimentos();

        if (inputActions.Player.Jump.WasPressedThisFrame())
        {
            Debug.Log("PULO APERTADO");
            jump = true;
        }

    }

    private void FixedUpdate() 
    { 
        MovePlayer(touchRun);

        if (jump) //se o pulo foi acionado
        {
            JumpPlayer();
        }
    } 


    void MovePlayer(float movimentoH) 
    { 
        playerRigidbody2d.linearVelocity = new Vector2(movimentoH * speed, playerRigidbody2d.linearVelocity.y); 
        if (movimentoH > 0 && !facingRigth) 
        { 
            Flip(); 
        } else if (movimentoH < 0 && facingRigth) 
        { 
            Flip(); 
        } 
    }

    void JumpPlayer()
    {
        if(isGround)
        {
            numberJumps = 0;
            CriarPoeira();
        }

        if(isGround || numberJumps < maximoJump)
        {
            playerRigidbody2d.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            isGround = false;
            numberJumps++;

            //tocar o som de cenoura coletada
            fxGame.PlayOneShot(fxPulo);

            CriarPoeira();
        }
        jump = false;
    }


    void Flip() 
    {
        CriarPoeira();

        facingRigth = !facingRigth; transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z); 
    }

    void SetaMovimentos()
    {
        playerAnimator.SetBool("Walk", playerRigidbody2d.linearVelocity.x != 0 && isGround);
        playerAnimator.SetBool("Jump", !isGround);
    }

    // identificando a colisão do objeto (cenoura) com o player
    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch(collision.gameObject.tag)
        {
            //para os coletáveis
            case "Coletaveis":

                _ControleGame.Pontuacao(1);

                Destroy(collision.gameObject);
                break;

            //para os inimigos
            case "Inimigo":


                //chama a animação de morte do player
                //instacia o prefab de explosão na posição do inimigo
                GameObject tempExplosao = Instantiate(_ControleGame.hitprefab, transform.position, transform.localRotation);
                Destroy(tempExplosao, 0.5f); //destroi o prefab de explosão após 0.5 segundos

                //adiciona uma força para cima no player ao tocar no inimigo
                Rigidbody2D rb = GetComponentInParent<Rigidbody2D>();
                rb.linearVelocity = new Vector2(rb.linearVelocity.x, 0f); //zera a velocidade vertical antes de aplicar a força
                rb.AddForce(new Vector2(0f, 8f), ForceMode2D.Impulse);

                //adiciona o som da explosão
                _ControleGame.fxGame.PlayOneShot(_ControleGame.fxExplosao);


                //destroi o inimigo ao tocar nele
                Destroy(collision.gameObject);
                break;

            case "Espinhos":
                Hurt();
                break;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        switch(collision.gameObject.tag)
        {

            case "Plataforma":
                this.transform.parent = collision.transform;
                break;

            case "Inimigo":
                Hurt();
                break;
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        switch(collision.gameObject.tag)
        {
            case "Plataforma":
                this.transform.parent = null;
                break;
        }
    }

    void Hurt()
    {
        if(!playerInvencivel)
        {

            playerInvencivel = true;

            vidas--; //= vidas - 1
            StartCoroutine(Dano());
            //atualiza a barra de vida no hud
            _ControleGame.BarraVida(vidas);

            if(vidas < 1)
            {
                GameObject pDieTemp = Instantiate(PlayerDie, transform.position, Quaternion.identity);
                Rigidbody2D rbDie = pDieTemp.GetComponent<Rigidbody2D>();
                rbDie.AddForce(new Vector2(150f, 500f));

                //chamando o som de morte do player
                _ControleGame.fxGame.PlayOneShot(_ControleGame.fxPlayerDie);

                Invoke("CarregaoJogo", 4f);

                gameObject.SetActive(false);
            }
        }
    }

    void CarregaoJogo()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    IEnumerator Dano()
    {

        srPlayer.color = noHitColor;
        yield return new WaitForSeconds(0.1f);

        for (float i=0; i < 1; i+= 0.1f)
        {
            srPlayer.enabled = false;
            yield return new WaitForSeconds(0.1f);
            srPlayer.enabled = true;
            yield return new WaitForSeconds(0.1f);
        }

        srPlayer.color = Color.white;
        playerInvencivel = false;
    }

    void CriarPoeira()
    {
        _poeira.Play();
    }
}
