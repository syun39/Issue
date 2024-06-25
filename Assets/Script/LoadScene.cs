using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    public void SceneLoad(string sceneName) // ƒV[ƒ“‘JˆÚ
    {
        SceneManager.LoadScene(sceneName);
    }
}
