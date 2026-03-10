using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public static SceneController instance;
    string sceneName;
    public GameObject pauseMenu;
    


    void Awake() {
        if(!instance){
            instance=this;
        }else if(instance!=this){
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }
    private void Start() 
    {
        
    }
        
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)){
            Scene currentScene = SceneManager.GetActiveScene ();
		    sceneName = currentScene.name;
            if (sceneName == "InGame")
            {
                pauseMenu.SetActive(true);
                Time.timeScale=0;
            }
        }
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void SiwtchScene(string scenename)
    {
        Debug.Log("sceneName to load: " + scenename);
        SceneManager.LoadScene(scenename);
    }
    public void BackToGame()
    {
        pauseMenu.SetActive(false);
        Time.timeScale=1;
    }

    


}
