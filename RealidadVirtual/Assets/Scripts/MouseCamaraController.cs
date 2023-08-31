using UnityEngine;

public class MouseCamaraController : MonoBehaviour
{
    public float sensitivity = 2.0f;  // Sensibilidad del movimiento del mouse
    public float speed = 5.0f;        // Velocidad de movimiento

    private float rotationX = 0.0f;
    private float rotationY = 0.0f;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;  // Bloquea el cursor para que no se vea y esté centrado en la ventana del juego
    }

    private void Update()
    {
        rotationX += Input.GetAxis("Mouse X") * sensitivity;
        rotationY -= Input.GetAxis("Mouse Y") * sensitivity;  // Invierte la rotación vertical

        rotationY = Mathf.Clamp(rotationY, -90f, 90f);  // Limita la rotación vertical entre -90 y 90 grados

        transform.localRotation = Quaternion.Euler(rotationY, rotationX, 0);  // Aplica la rotación a la cámara

        // Movimiento de la cámara
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 moveDirection = new Vector3(horizontalInput, 0, verticalInput);
        moveDirection = transform.TransformDirection(moveDirection);  // Transforma el movimiento en función de la rotación de la cámara

        transform.position += moveDirection * speed * Time.deltaTime;
    }
}
