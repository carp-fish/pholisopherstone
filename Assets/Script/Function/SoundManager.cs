using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;
    [SerializeField]private AudioSource _musicSource, _effectSource;
    // Start is called before the first frame update
   void Awake()
   {
    if(Instance==null)
    {
        Instance=this;
        DontDestroyOnLoad(gameObject);
    }
    else{
        Destroy(gameObject);
    }
   }
public void PlaySound(AudioClip clip)
{
  _effectSource.PlayOneShot(clip);
}

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
