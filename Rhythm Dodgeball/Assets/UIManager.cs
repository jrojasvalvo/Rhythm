using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        SceneManager.LoadScene("SongSelectionScreen");
    }

    //add more functions to load levels as needed
    public void Level1()
    {
        SceneManager.LoadScene("Level 1");
    }
}
