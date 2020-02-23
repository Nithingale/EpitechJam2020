using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class morseControl : MonoBehaviour
{
    public float speed;
    public float acceleration;
    public Vector3 target;

    public Transform check;
    public LayerMask whatIsMorse;

    public GameObject progress;

    private float levelScore;

    private bool end;
    private float timer;

    // Start is called before the first frame update
    void Start()
    {
        levelScore = .0f;
        Score scr = StaticClass.CrossSceneInformation.GetComponent<Score>();
        scr.Activate();
        end = false;
        timer = 0.0f;
        Time.timeScale = 1f;
    }

    // Update is called once per frame
    void Update()
    {        
        speed += acceleration * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
        if (end) {
            timer += Time.deltaTime;
            if (timer > 3)
            {
                int rand = SceneManager.GetActiveScene().buildIndex;
                while (SceneManager.GetActiveScene().buildIndex == rand) {
                    rand = Random.Range(1, 4);
                }
                SceneManager.LoadScene(sceneBuildIndex: rand);
            }
        }
        if (transform.position.x == target.x) {
            end = true;
        } else {
            if (Physics2D.OverlapCircle(check.position, 0f, whatIsMorse)) {
                if (Input.GetKey(KeyCode.Space)) {
                    levelScore += Time.deltaTime;
                } else {
                    levelScore -= Time.deltaTime * 2.0f;
                }
            } else if (Input.GetKey(KeyCode.Space)) {
                levelScore -= Time.deltaTime * 4.0f;
            }
            levelScore = Mathf.Clamp(levelScore, -1.0f, 1.0f);
            if (levelScore == -1.0f) {
                end = true;
            }

            var progressRenderer = progress.GetComponent<Renderer>();
            float r = Mathf.Clamp(-levelScore, .0f, 1.0f);
            float g = Mathf.Clamp(levelScore, .0f, 1.0f);
            Color progressColor = new Color(r, g, .0f);
            progressRenderer.material.SetColor("_Color", progressColor);
        }
    }
}
