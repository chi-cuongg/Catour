using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class StickController : MonoBehaviour
{
    public float extendSpeed = 5f;
    public float rotateSpeed = 90f;
    private bool isExtending = false;
    private bool isRotating = false;
    private bool control = true;
    private Vector3 axisPoint;
    private SpawnObject spawn;
    private GameObject cat;

    void Awake()
    {
        spawn = GameObject.Find("GameManager").GetComponent<SpawnObject>();
        cat = GameObject.Find("Cat");
    }

    void Update()
    {
        if(control){
            if (Input.GetKeyDown(KeyCode.Space))
            {
                isExtending = true;
            }

            if (Input.GetKeyUp(KeyCode.Space))
            {
                float height = (gameObject.GetComponent<BoxCollider2D>().size.y * transform.localScale.y) / 2;
                axisPoint = transform.position - new Vector3(0, height, 0);

                isExtending = false;
                isRotating = true;
                control = false;
            }
        }

        if (isExtending)
        {
            if(transform.localScale.y < 4){
                float extendAmount = extendSpeed * Time.deltaTime;
                transform.localScale += new Vector3(0, extendAmount, 0);
                transform.position += new Vector3(0, extendAmount / 2, 0);
            }else isExtending = false;
        }

        if (isRotating)
        {
            transform.RotateAround(axisPoint, Vector3.back, rotateSpeed * Time.deltaTime);
        }
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.CompareTag("Square")){
            Move();
        }
    }

    private void Move(){
        isRotating = false;
        spawn.Next();
        cat.GetComponent<Movement>().Move(this.gameObject);
    }
}
