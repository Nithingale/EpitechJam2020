using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveHand : MonoBehaviour
{
    public float speed;
    public float speedIncrement = 10f;
    public Vector3 targetRight;
    public Vector3 targetLeft;

    private Vector3 target;
    private Vector3 targetUp;
    private Vector3 targetDown;
    private Vector3 position;
    // Start is called before the first frame update
    void Start()
    {
        target = targetRight;
        Score scr = StaticClass.CrossSceneInformation.GetComponent<Score>();
        scr.Activate();
    }

    // Update is called once per frame
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
                Debug.Log("Going down");
            }
        }
        else if (transform.position == targetRight)
        {
            Debug.Log("Going Left");
            target = targetLeft;
        }
        else if (transform.position == targetLeft)
        {
            Debug.Log("Going Right");
            target = targetRight;
        }
        else if (transform.position == targetDown)
        {
            Debug.Log("Going up");
            target = new Vector3(transform.position.x, targetUp.y, target.z);
        }
        else if (transform.position == targetUp)
        {
            Debug.Log("Going Right");
            target = targetRight;
        }
    }
}
