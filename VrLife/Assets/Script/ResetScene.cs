using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetScene : MonoBehaviour
{
    
    public void ResetSceneButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
