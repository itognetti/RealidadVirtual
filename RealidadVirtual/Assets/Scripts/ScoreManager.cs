using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public Text scoreText; 
    public GameObject hoyo;
    public GameObject palo;

    private int score = 0;
    private int shots = 0;

    private void Start()
    {
        UpdateText();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Hole")
        {
            score++;
        }
        else if (collision.gameObject.name =="Golf Club")
        {
            shots++;
        }
            UpdateText();

    }

    private void UpdateText()
    {
        // Actualiza el texto en el Canvas con el nuevo puntaje
        if (scoreText != null)
        {
            scoreText.text = "Puntaje: " + score + "\nDisparos: " + shots;
        }
    }
}
