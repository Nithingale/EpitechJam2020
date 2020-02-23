using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class characterController : MonoBehaviour
{
    private Rigidbody2D rb;
    private float current_speed;
    private float timer;
    private bool lose;
    private Score scr;

    public Transform topCheck;
    public Transform botCheck;
    public Transform leftCheck;
    public Transform rightCheck;
    public LayerMask whatIsObject;
    public LayerMask whatIsWin;
    public float jumpForce = 4f;
    public float speed = 4f;
    public float speedIncrement = 0.1f;
    public GameObject restart;
    public GameObject win;
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        current_speed = speed;
        scr = StaticClass.CrossSceneInformation.GetComponent<Score>();
        scr.Activate();
        timer = 0;
        Time.timeScale = 1f;
        lose = false;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 movement = new Vector3(1f, 0f, 0f);
        transform.position += movement * Time.deltaTime * current_speed;

        if (Input.GetKey(KeyCode.Space))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            current_speed += speedIncrement;
        }
        if (Input.GetKey(KeyCode.R))
        {
            current_speed = speed;
            transform.position = new Vector3(0, 0, 0);
            Time.timeScale = 1f;
            restart.SetActive(false);
        }
        if (Physics2D.OverlapCircle(botCheck.position, 0f, whatIsWin) || Physics2D.OverlapCircle(topCheck.position, 0f, whatIsWin) || Physics2D.OverlapCircle(rightCheck.position, 0f, whatIsWin) || Physics2D.OverlapCircle(leftCheck.position, 0f, whatIsWin))
        {
            win.SetActive(true);
            timer = 0;
            Time.timeScale = 0f;
        }
        if (Physics2D.OverlapCircle(botCheck.position, 0f, whatIsObject) || Physics2D.OverlapCircle(topCheck.position, 0f, whatIsObject) || Physics2D.OverlapCircle(rightCheck.position, 0f, whatIsObject) || Physics2D.OverlapCircle(leftCheck.position, 0f, whatIsObject))
        {
            lose = true;
        }
        if (win.activeSelf || lose) {
            SceneManager.LoadScene(0);
            scr.setScore(0);
            scr.Desactivate();
        }
    }
}
