using UnityEngine;
using UnityEngine.SceneManagement;

public class TelaMorte : MonoBehaviour
{
    public void Reiniciar()
    {
        SceneManager.LoadScene(1);
    }
    public void MenuPrincipal()
    {
        SceneManager.LoadScene(0);
    }
}
