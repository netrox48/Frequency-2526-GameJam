using UnityEngine;
using UnityEngine.SceneManagement;

public class MainStory : MonoBehaviour
{
    void Start()
    {
        // 5 saniye sonra "NextScene" adlý sahneye geç
        Invoke("LoadNextScene", 30f);
    }

    void LoadNextScene()
    {
        SceneManager.LoadScene("LEVEL1"); // Buraya sahne adýný yaz
    }
}

