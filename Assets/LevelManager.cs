using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class LevelManager : MonoBehaviour
{
    PlayerController playerController;
    public TextMeshProUGUI textmPro;
    public int level=1;
   void Start(){
      Debug.Log(SceneManager.GetActiveScene().buildIndex);
       if(SceneManager.GetActiveScene().buildIndex==0){
           PlayerPrefs.DeleteAll();
       }
            level=PlayerPrefs.GetInt("Level",1);
            //PlayerPrefs.DeleteAll();
   }
    void Update(){
          textmPro.text="LEVEL "+(SceneManager.GetActiveScene().buildIndex+1).ToString();
    }

    // Start is called before the first frame upda
    public void NextLevel(){

       PlayerPrefs.SetInt("Level",PlayerPrefs.GetInt("Level")+1);
       SceneManager.LoadScene(PlayerPrefs.GetInt("Level"));
       Debug.Log(SceneManager.GetActiveScene().buildIndex);
       
    } 
    public void RestartGame(){
        if(SceneManager.GetActiveScene().buildIndex==0){
            Time.timeScale=1f;
            SceneManager.LoadScene(0);
        }else{
        Time.timeScale=1f;
        SceneManager.LoadScene(PlayerPrefs.GetInt("Level"));
        }

        
    }
}
