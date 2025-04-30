using UnityEngine;
using UnityEngine.SceneManagement;

public class ChamarPausa : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.timeScale != 0 && Input.GetKeyUp(KeyCode.Escape))
        {
            SceneManager.LoadSceneAsync(2, LoadSceneMode.Additive);
            Time.timeScale = 0;
        }
    }
}
