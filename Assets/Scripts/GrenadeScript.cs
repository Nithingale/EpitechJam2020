using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeScript : MonoBehaviour
{
    public float speed;
    public Vector3 startPoint;
    public Vector3 endPoint;

    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        startPoint = new Vector3(-4, -1, 0);
        endPoint = new Vector3(4, 1, 0);

        rb = gameObject.GetComponent<Rigidbody2D>();
        Score scr = StaticClass.CrossSceneInformation.GetComponent<Score>();
        scr.Activate();
    }

    // Update is called once per frame
    void Update()
    {
        //rb.AddForce(new Vector2(3f, 3f));
    }
}
