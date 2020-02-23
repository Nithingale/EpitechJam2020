using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class shakeAlarm : MonoBehaviour
{
    private float startTime;
    public bool isShaking;
    public float speed;
    public Vector3 targetRight;
    public Vector3 targetLeft;
    public Transform check;
    public LayerMask whatIsHand;

    private float time;
    private Vector3 target;
    // Start is called before the first frame update
    void Start()
    {
        isShaking = false;
        startTime = Random.Range(2, 5);
        target = targetRight;
        Time.timeScale = 1f;
        time = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (Physics2D.OverlapCircle(check.position, 0f, whatIsHand))
        {
            if (isShaking)
            {
                //you win
                SceneManager.LoadScene("winWakeUp", LoadSceneMode.Single);
            }
        }
        if (startTime < time) {
            isShaking = true;
            float step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, target, step);

            if (transform.position == targetRight)
            {
                target = targetLeft;
            }
            else if (transform.position == targetLeft)
            {
                target = targetRight;
            }
        }
    }
}
