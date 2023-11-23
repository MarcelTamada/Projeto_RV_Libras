using UnityEngine;
using UnityEngine.UI;

public class DesrenderizarRawImage : MonoBehaviour
{
    public RawImage rawImage;
    private float tempoSemTecla = 0f;
    private bool rawImageAtiva = false;

    void Start()
    {
        // Desativa a RawImage no início
        rawImage.enabled = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.B) || Input.GetKeyDown(KeyCode.C) ||
            Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.F) ||
            Input.GetKeyDown(KeyCode.G) || Input.GetKeyDown(KeyCode.H) || Input.GetKeyDown(KeyCode.I) ||
            Input.GetKeyDown(KeyCode.J) || Input.GetKeyDown(KeyCode.K) || Input.GetKeyDown(KeyCode.L) ||
            Input.GetKeyDown(KeyCode.M) || Input.GetKeyDown(KeyCode.N) || Input.GetKeyDown(KeyCode.O) ||
            Input.GetKeyDown(KeyCode.P) || Input.GetKeyDown(KeyCode.Q) || Input.GetKeyDown(KeyCode.R) ||
            Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.T) || Input.GetKeyDown(KeyCode.U) ||
            Input.GetKeyDown(KeyCode.V) || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.X) ||
            Input.GetKeyDown(KeyCode.Y) || Input.GetKeyDown(KeyCode.Z))
        {
            // Se alguma tecla for pressionada, reinicia o temporizador
            tempoSemTecla = 0f;

            // Se a RawImage estiver desativada, a reativa
            if (!rawImageAtiva)
            {
                rawImage.enabled = true;
                rawImageAtiva = true;
            }
        }
        else
        {
            // Nenhuma tecla foi pressionada, incrementa o temporizador
            tempoSemTecla += Time.deltaTime;

            // Se o temporizador atingir 6 segundos e a RawImage estiver ativa, a desativa
            if (tempoSemTecla >= 5f && rawImageAtiva)
            {
                rawImage.enabled = false;
                rawImageAtiva = false;
            }
        }
    }
}
