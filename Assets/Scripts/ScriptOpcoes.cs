using UnityEngine;
using UnityEngine.SceneManagement;

public class ScriptOpcoes : MonoBehaviour
{
    private static int qualCena;
    public static void Open(int QualCena)
    {
        qualCena = QualCena;
        SceneManager.LoadSceneAsync(3, LoadSceneMode.Additive);
    }
    public void Return()
    {
        if (qualCena == 2)
        {
            BotaoPausa.Open();
            SceneManager.UnloadScene(3);
        }
        else if (qualCena == 0)
        {
            SceneManager.UnloadScene(3);
        }
    }
}
