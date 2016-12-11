using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ScoreManager : MonoBehaviour {

    private GameObject winner;

    private List<GameObject> playersGameObjects;
    private List<int> playersScores;

    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }
 
    public void SetWinner(GameObject p) { winner = p; }
}
