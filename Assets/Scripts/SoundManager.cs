using UnityEngine;
using System.Collections;

public class SoundManager : MonoBehaviour
{

    private static SoundManager instance = null;
    public static SoundManager Instance;
    
    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }
}