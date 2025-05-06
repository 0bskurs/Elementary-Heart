using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BotaoPausa : MonoBehaviour
{
    public void resume()
    {
        StartCoroutine(resumeCoroutine());
    }
    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            StartCoroutine(resumeCoroutine());
        }
    }
    private IEnumerator resumeCoroutine()
    {
        Time.timeScale = 1f;
        SceneManager.UnloadScene(2);
        yield return new WaitForSeconds(0.3f);
    }
    public static void Open()
    {
        SceneManager.LoadSceneAsync(2, LoadSceneMode.Additive);
    }
    public void Opcoes()
    {
        ScriptOpcoes.Open(2);
        SceneManager.UnloadScene(2);
    }
    public void Principal()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
        
    }
}
