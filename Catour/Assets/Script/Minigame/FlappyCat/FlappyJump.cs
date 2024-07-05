using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlappyJump : MonoBehaviour
{
    public Controller Control;
    private Rigidbody2D m_Rigidbody2D;
    bool jump = false;
    private int m_JumpForce = 200;
    public GameOver gameOver;
    // Start is called before the first frame update
    void Start()
    {
        m_Rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Control.isControl()){
            if (Input.GetButtonDown("Jump"))
            {
                jump = true;
            }
        }
    }

    void FixedUpdate()
    {
        if(jump){
            m_Rigidbody2D.velocity = Vector2.zero;
            m_Rigidbody2D.AddForce(Vector2.up * m_JumpForce);
            jump = false;
        }
    }

    private void OnDestroy() {
        if(gameOver != null)
            gameOver.setGameOver();
    }
}
