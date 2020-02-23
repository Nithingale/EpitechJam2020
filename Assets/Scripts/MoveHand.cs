using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveHand : MonoBehaviour
{
    public int life = 3;
    public float speed;
    public float speedIncrement = 10f;
    public Vector3 targetRight;
    public Vector3 targetLeft;

    private Vector3 target;
    private Vector3 targetUp;
    private Vector3 targetDown;
    private Vector3 position;

    void Start()
    {
        target = targetRight;
        Score scr = StaticClass.CrossSceneInformation.GetComponent<Score>();
        scr.Activate();
    }

    void Update()
    {
        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, target, step);

        if (Input.GetKeyDown("space"))
        {
            speed += speedIncrement;
            if (transform.position.y == 3)
            {
                targetDown = new Vector3(transform.position.x, target.y - 6, target.z);
                targetUp = new Vector3(transform.position.x, target.y, target.z);
                target = targetDown;
            }
            life -= 1;
        }
        else if (transform.position == targetRight)
        {
            target = targetLeft;
        }
        else if (transform.position == targetLeft)
        {
            target = targetRight;
        }
        else if (transform.position == targetDown)
        {
            target = new Vector3(transform.position.x, targetUp.y, target.z);
        }
        else if (transform.position == targetUp)
        {
            target = targetRight;
        }
        if (life <= 0)
        {
            //you lose
            SceneManager.LoadScene("loseWakeUp", LoadSceneMode.Single);
        }
    }
}
