using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletTime : MonoBehaviour
{
    public float slowdownFactor =0.05f;
    public float slowdownLength =2F;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Time.timeScale +=(1f/slowdownLength)*Time.unscaledDeltaTime;
        Time.timeScale = Mathf.Clamp(Time.timeScale,0f,1f);
    }
    public void DoBulletTime()
    {
     Time.timeScale =slowdownFactor;
     Time.fixedDeltaTime=Time.timeScale*.02f;
    }
}
