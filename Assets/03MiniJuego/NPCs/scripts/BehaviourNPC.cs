using UnityEngine;
using System.Collections;
using TMPro;
using UnityEngine.UI;
public class BehaviourNPC : MonoBehaviour
{
    private bool isPlayer;
    private bool didDialogueStart;
    private int indexLine;

    [SerializeField]private GameObject aviso;
    [SerializeField, TextArea(6, 4)] private string[] lineaTexto;
    [SerializeField] private GameObject panelDialogo;
    [SerializeField] private TMP_Text textoDialogo;
    // Update is called once per frame
    // Nuevas variables para el sistema de preguntas
    [SerializeField] private GameObject panelPreguntas;
    [SerializeField] private Button[] botonesRespuestas; // Asigna 2 botones en el Inspector
    [SerializeField] private TMP_Text textoPregunta;
    private int preguntaActual = 0;

    // Preguntas y respuestas
    [System.Serializable]
    public struct Pregunta
    {
        public string pregunta;
        public string[] respuestas; // 2 respuestas (0 = correcta, 1 = incorrecta)
        public int respuestaCorrecta;
    }

    [SerializeField] private Pregunta[] preguntas;

    void Start()
    {
        // Configurar listeners para los botones
        for (int i = 0; i < botonesRespuestas.Length; i++)
        {
            int index = i; // Capturar el índice para el closure
            botonesRespuestas[i].onClick.RemoveAllListeners();
            botonesRespuestas[i].onClick.AddListener(() => ResponderPregunta(index));
        }

        panelPreguntas.SetActive(false);
    }



    void Update()
    {
        if (isPlayer && Input.GetKeyUp(KeyCode.Space))
        {
            if (!didDialogueStart)
            {
                EmpezarDialogo();
            }
            else if (textoDialogo.text == lineaTexto[indexLine])
            {
                // Verificar si la línea actual es una pregunta
                if (indexLine == 2 || indexLine == 5 || indexLine == 8) // Suponiendo que las preguntas están en estas líneas
                {
                    MostrarPregunta(preguntaActual);
                }
                else
                {
                    SiguienteLinea();
                }
            }
            else
            {
                StopAllCoroutines();
                textoDialogo.text = lineaTexto[indexLine];
            }
        }
    }

    public void EmpezarDialogo()
    {
        didDialogueStart = true;
        panelDialogo.SetActive(true);
        aviso.SetActive(false);
        indexLine = 0;
        StartCoroutine(MostrarLineas());
    }
    private IEnumerator MostrarLineas()
    {
        textoDialogo.text=string.Empty;
        foreach(char c in lineaTexto[indexLine])
        {
            textoDialogo.text+=c;
            yield return new WaitForSeconds(0.05f);
        }
    }

    private void SiguienteLinea()
    {
        indexLine++;
        if(indexLine< lineaTexto.Length)
        {
            StartCoroutine(MostrarLineas());
        }
        else
        {
            didDialogueStart=false;
            panelDialogo.SetActive(false);
            aviso.SetActive(true);
        }
    }

    private void MostrarPregunta(int numPregunta)
    {
        // Pausar el diálogo
        StopAllCoroutines();
        panelDialogo.SetActive(false);

        // Mostrar panel de preguntas
        panelPreguntas.SetActive(true);
        textoPregunta.text = preguntas[numPregunta].pregunta;

        // Asignar textos a los botones
        for (int i = 0; i < botonesRespuestas.Length; i++)
        {
            botonesRespuestas[i].GetComponentInChildren<TMP_Text>().text = preguntas[numPregunta].respuestas[i];
        }
    }

    private void ResponderPregunta(int respuestaIndex)
    {
        // Obtener el botón presionado
        Button botonPresionado = botonesRespuestas[respuestaIndex];

        if (respuestaIndex != preguntas[preguntaActual].respuestaCorrecta)
        {
            Debug.Log("Respuesta incorrecta!");

            //Cambiar color del botón a rojo 
            botonPresionado.image.color = Color.red;

            // Desactivar solo este botón
            // botonPresionado.interactable = false;

            // No incrementar preguntaActual, para permitir reintentos
            return; //Salir sin avanzar.
        }
        else
        {
            Debug.Log("Respuesta correcta!");

            // Restaurar colores de todos los botonespor si alguno estaba rojo
            foreach (var boton in botonesRespuestas)
            {
                boton.image.color = Color.white; // Color original
            }

            // Ocultar panel de preguntas y continuar diálogo
            panelPreguntas.SetActive(false);
            panelDialogo.SetActive(true);
            preguntaActual++;
            SiguienteLinea();
        }
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        isPlayer = true;
        aviso.SetActive(true);
        Debug.Log("ya estoy");
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        isPlayer = false;
        Debug.Log("me fui");
        aviso.SetActive(false);
    }
}
