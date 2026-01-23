using UnityEngine;

public class IASlug : MonoBehaviour
{

    public Transform enemie;
    public SpriteRenderer enemieSprite;
    public Transform[] position;
    public float speed;
    public bool isRight;

    public int idTarget;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        enemieSprite = enemie.gameObject.GetComponent<SpriteRenderer>();
        enemie.position = position[0].position;
        idTarget = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (enemie != null)
        {
            enemie.position = Vector2.MoveTowards(enemie.position, position[idTarget].position, speed * Time.deltaTime);

            if (enemie.position == position[idTarget].position)
            {
                idTarget += 1; //para ir pra segunda posição (ponto b)

                if (idTarget == position.Length)
                {
                    idTarget = 0; //volta para a primeira posição (ponto a)
                }
            }

            if (position[idTarget].position.x < enemie.position.x && isRight == true)
            {
                Flip();
            }
            else if (position[idTarget].position.x > enemie.position.x && isRight == false)
            {
                Flip();
            }
        }
    }

    void Flip()
    {
        isRight = !isRight;
        enemieSprite.flipX = !enemieSprite.flipX;  
    }

}
