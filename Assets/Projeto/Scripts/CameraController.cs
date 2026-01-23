using UnityEngine;

public class CameraController : MonoBehaviour
{

    public float offsetX = 3f; //mede a distancia do eixo x do jogador e da camera
    public float smooth = 0.1f; //controla a suavidade da camera ao seguir o player (menor = melhor)

    //controlam a limitação da camera em todas as direções
    public float limiteUp = 2f;
    public float limiteDown = 0f;
    public float limiteLeft = 0f;
    public float limiteRigth = 100f;

    private Transform player;
    private float playerX;
    private float playerY;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = FindAnyObjectByType<PlayerController>().transform;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(player != null)
        {
            //player ter valores do transform
            playerX = Mathf.Clamp(player.position.x + offsetX, limiteLeft, limiteRigth);
            playerY = Mathf.Clamp(player.position.y, limiteDown, limiteUp);

            transform.position = Vector3.Lerp(transform.position, new Vector3(playerX, playerY, transform.position.z), smooth); 
        }
    }
}
