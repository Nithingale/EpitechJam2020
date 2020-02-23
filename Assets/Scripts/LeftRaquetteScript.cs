using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftRaquetteScript : MonoBehaviour
{
    public float speed;
    public GameObject Grenada;
    private Vector3 targetUp;
    private Vector3 targetDown;
    private Vector3 target;
    public float targetTime;

    // Start is called before the first frame update
    void Start()
    {
        targetTime = 0.0f;
        targetDown = transform.position;
        targetUp = new Vector3(transform.position.x, (float)(transform.position.y + 1), transform.position.z);
        target = targetDown;
    }

    // Update is called once per frame
    void Update()
    {
        float step = speed * Time.deltaTime;
        targetTime -= Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, target, step);

        if (targetTime <= 0.0f)
        {
            timerEnded();
        }

        if (transform.position.y == targetUp.y)
        {
            target = targetDown;
            transform.Rotate(Vector3.forward * - 20);
        }
    }

    void timerEnded()
    {
        if (Input.GetKeyDown("space"))
        {
            Transform tr = Grenada.GetComponent<Transform>();
            if (tr.position.y <= -0.5f && tr.position.y >= -2f && tr.position.x < -3 && tr.position.x > -5)
            {
                Rigidbody2D rb = Grenada.GetComponent<Rigidbody2D>();
                rb.velocity = new Vector3(0f, 0f, 0f);
                rb.AddForce(new Vector2(315f, 315f));
                tr.position = new Vector3(-4, -1, 0);
            }
            if (transform.position.y == targetDown.y)
            {
                transform.Rotate(Vector3.forward * + 20);
                target = targetUp;
            }
            targetTime = 0.7f;
        }
    }
}
