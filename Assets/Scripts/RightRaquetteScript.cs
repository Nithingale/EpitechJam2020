using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RightRaquetteScript : MonoBehaviour
{
    public GameObject Grenada;
    private Vector3 targetUp;
    private Vector3 targetDown;
    private Vector3 target;
    private float startTime;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        targetDown = transform.position;
        startTime = Random.Range(7, 9);
        targetUp = new Vector3(transform.position.x, (float)(transform.position.y + 1), transform.position.z);
        target = targetDown;
    }

    // Update is called once per frame
    void Update()
    {
        Transform tr = Grenada.GetComponent<Transform>();

        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, target, step);

        if (transform.position.y == targetUp.y)
        {
            Debug.Log("toto");
            target = targetDown;
            transform.Rotate(Vector3.forward * + 20);
        }

        if (tr.position.y <= -0.5f && tr.position.x < 5 && tr.position.x > 3)
        {
            if (startTime > Time.time)
            {
                Debug.Log("Smash");
                if (transform.position.y == targetDown.y)
                {
                    Rigidbody2D rb = Grenada.GetComponent<Rigidbody2D>();
                    rb.velocity = new Vector3(0f, 0f, 0f);
                    rb.AddForce(new Vector2(-315f, 315f));
                    tr.position = new Vector3(4, -1, 0);

                    transform.Rotate(Vector3.forward * -20);
                    target = targetUp;
                }
            }
        }

        if (tr.position.y <= -3f && tr.position.x > 4)
        {
            //you win
            SceneManager.LoadScene("Win", LoadSceneMode.Single);
        }
        if (tr.position.y <= -3f && tr.position.x < -4)
        {
            //you loose
            SceneManager.LoadScene("Loose", LoadSceneMode.Single);
        }
    }
}