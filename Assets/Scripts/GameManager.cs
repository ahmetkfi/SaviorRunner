using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public TextMeshProUGUI scoreText;
    
    PlayerController playerController;

    void Start()
    {
        playerController=FindObjectOfType<PlayerController>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if(playerController.siringaSayisi==-1){
            scoreText.text="0";
        }else{
         scoreText.text=playerController.siringaSayisi.ToString();  
        }
            if(!playerController.levelFinish){
                if(playerController.siringaSayisi>=playerController.gecerSayi){
                scoreText.color=Color.green;
            }else{
                scoreText.color=Color.red;
            }
            }
           
    }
}
