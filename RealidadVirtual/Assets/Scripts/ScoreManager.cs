using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    Rigidbody ball;
    public Text scoreText; 
    public GameObject hoyo;
    public GameObject palo;

    private int score = 0;
    private int shots = 0;

    private void Start()
    {
        ball = GetComponent<Rigidbody>();
        UpdateText();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Hole")
        {
            score++;
            ball.position = new Vector3(0, 0.12f, -3f);
            ball.velocity = Vector3.zero;
            ball.rotation = Quaternion.Euler(0, 0, 0);

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
