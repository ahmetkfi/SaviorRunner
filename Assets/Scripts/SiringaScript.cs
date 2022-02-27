using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SiringaScript : MonoBehaviour
{
    // Start is called before the first frame update
    PlayerController playerController;
   
    
    void Start()
    {   
           playerController=FindObjectOfType<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter(Collision col){
        if(col.gameObject.tag=="sick"){
            playerController.siringaSayisi--;
            if(playerController.siringaSayisi==-1){
                playerController.siringaSayisi=0;
            }
            Destroy(gameObject);
            playerController.Healing(1);
        }
    }
}
