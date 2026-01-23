using UnityEngine;
//using que permite a troca de cenas
using UnityEngine.SceneManagement;

public class ControllerScenes : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       if(Input.GetKeyDown(KeyCode.Return))
        {
            EnterPressionado();
        }
    }

    public void EnterPressionado()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
