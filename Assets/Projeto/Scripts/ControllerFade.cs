using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class ControllerFade : MonoBehaviour
{

    public static ControllerFade _instanciaFade;

    public Image _imagemFade;
    public Color _corInicial;
    public Color _corFinal;
    public float _duracaoFade;

    public bool _isFade;
    private float _tempo;

    void Awake()
    {
        _instanciaFade = this;
    }

    IEnumerator InicioFade()
    {
        _isFade = true;
        _tempo = 0f;

        while(_tempo <= _duracaoFade)
        {
            _imagemFade.color = Color.Lerp(_corInicial, _corFinal, _tempo / _duracaoFade);
            _tempo = _tempo + Time.deltaTime;
            yield return null;
        }

        _isFade = false;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(InicioFade());    
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
