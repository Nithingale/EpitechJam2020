using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class End : MonoBehaviour
{
    private float timer;

    public bool lose = false;

    void Start()
    {
        timer = 0.0f;
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer > 3)
        {
            if (lose)
            {
                Score scr = StaticClass.CrossSceneInformation.GetComponent<Score>();
                SceneManager.LoadScene(0);
                scr.setScore(0);
                scr.Desactivate();
                return;
            }
            int rand = Random.Range(1, 5);
            SceneManager.LoadScene(sceneBuildIndex: rand);
        }
    }
}
