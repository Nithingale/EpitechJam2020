using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class startGame : MonoBehaviour
{
    public GameObject text;
    public GameObject panel;
    public int nbScene = 4;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space))
        {
            int rand = SceneManager.GetActiveScene().buildIndex;
            while (SceneManager.GetActiveScene().buildIndex == rand) {
                rand = Random.Range(1, nbScene);
            }
            DontDestroyOnLoad(panel);
            StaticClass.CrossSceneInformation = text;
            SceneManager.LoadScene(sceneBuildIndex:rand);
        }
    }
}
