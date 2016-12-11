using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ScoreManager : MonoBehaviour {

    public GameObject playerOne;
    public GameObject playerTwo;
    public GameObject playerThree;
    public GameObject playerFour;

    private List<GameObject> playersGameObjects;
    private List<int> playersScores;
    private List<GameObject> players;
  
    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        playersScores = new List<int>();
        players = new List<GameObject>{ playerOne, playerTwo, playerThree, playerFour };
    }
 
    public void GrabScores()
    {
        for (int i = 0; i < players.Count; i++)
        {
            playersScores.Add(players[i].GetComponent<PlayerMovement_Jacket>().GetPoints());
        }
    }

    public List<int> GetScores()
    {
        return playersScores;
    }
}
