using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    public void SceneLoad(string sceneName) // �V�[���J��
    {
        SceneManager.LoadScene(sceneName);
    }
}
