using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Score : MonoBehaviour
{
    private TextMeshProUGUI scoreText;
    float timer = 0.0f;
    private bool isActivate;
    // Start is called before the first frame update
    void Start()
    {
        scoreText = GetComponent<TextMeshProUGUI>();
        isActivate = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isActivate)
        {
            Debug.Log("Here");
            timer += Time.deltaTime;
        }
        int secs = Mathf.CeilToInt(timer % 60);
        scoreText.text = "Score: " + secs.ToString();
    }

    public void Activate()
    {
        isActivate = true;
    }

    public void Desactivate()
    {
        isActivate = false;
    }
}
