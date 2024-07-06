using UnityEngine;

public class StickController : MonoBehaviour
{
    public float extendSpeed = 5f;
    public float rotateSpeed = 90f;
    private bool isExtending = false;
    private bool isRotating = false;
    private Quaternion targetRotation;
    private Vector3 initialScale;
    private Vector3 initialPosition;

    void Start()
    {
        initialPosition = transform.localPosition;
        initialScale = transform.localScale;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            isExtending = true;
            isRotating = false;
        }

        if (Input.GetKey(KeyCode.Space))
        {
            if (isExtending)
            {
                float extendAmount = extendSpeed * Time.deltaTime;
                transform.localScale += new Vector3(0, extendAmount, 0);
                transform.localPosition = new Vector3(initialPosition.x, initialPosition.y + (extendAmount / 2), initialPosition.z);
            }
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            isExtending = false;
            isRotating = true;
            targetRotation = Quaternion.Euler(0, 0, -90);
        }

        if (isRotating)
        {
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotateSpeed * Time.deltaTime);
            if (Quaternion.Angle(transform.rotation, targetRotation) < 0.1f)
            {
                isRotating = false;
            }
        }
    }
}
