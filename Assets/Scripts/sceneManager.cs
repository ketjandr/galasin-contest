using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneManager : MonoBehaviour
{
    public static sceneManager instance;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    public void OpenScene(int sceneNo)
    {
        SceneManager.LoadScene(sceneNo);
    }
}
