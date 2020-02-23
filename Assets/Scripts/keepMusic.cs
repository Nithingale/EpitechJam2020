using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class keepMusic : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }
    private static keepMusic instance = null;
    public static keepMusic Instance
    {
        get { return instance; }
    }

    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        else
        {
            instance = this;
        }
        DontDestroyOnLoad(this.gameObject);
    }
}