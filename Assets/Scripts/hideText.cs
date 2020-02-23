using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class hideText : MonoBehaviour
{
    public GameObject Text;

    // Start is called before the first frame update
    void Start()
    {
        if (SceneManager.GetActiveScene().buildIndex == 0)
            Text.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
