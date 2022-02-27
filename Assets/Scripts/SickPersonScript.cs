using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SickPersonScript : MonoBehaviour
{
    // Start is called before the first frame update
    public Animator animator;
    public GameObject particleSystem;
    public void Awake(){
        animator=GetComponent<Animator>();
        
      
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Healing(){
        animator.SetBool("isHeal",true);
        particleSystem.SetActive(true);
        
    }
}
