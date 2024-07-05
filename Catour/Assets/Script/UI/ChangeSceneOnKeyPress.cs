using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeSceneOnKeyPress : MonoBehaviour
{
    // Tên của scene bạn muốn chuyển đến
    public string sceneName;

    void Update()
    {
        // Kiểm tra nếu phím F được nhấn
        if (Input.GetKeyDown(KeyCode.F))
        {
            // Chuyển sang scene khác
            SceneManager.LoadScene(sceneName);
        }
    }
}