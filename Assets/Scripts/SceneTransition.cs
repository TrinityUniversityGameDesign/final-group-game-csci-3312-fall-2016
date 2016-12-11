using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour {

    public string nextScene;

    public void LoadScene() { SceneManager.LoadScene(nextScene);  }
}
