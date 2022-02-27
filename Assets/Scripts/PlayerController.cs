using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerController : MonoBehaviour
{
    public GameObject camera2;
    public GameObject startBar;
    public bool levelComplete;
    private float  movementSpeed=15f;
    private float horSpeed=.25f;
    public int siringaSayisi;
    public GameObject[] siringa;
    public int gecerSayi;
    private float boostTimer;
    private bool boosting;
    public Transform bulletSiringa,nokta;
    float hor;
    // Start is called before the first frame update
    private Animator animator;    
    private ParticleSystem dust;
    private int maxHealt;
    private int currentHealt;
    public bool levelFinish;
    Transform klon;
   public  HeltBar healtBar;
   public GameObject healtBarOBJ;
   public GameObject levelFinishPanel;
   public GameObject gameOverPanel;
   private SickPersonScript sickPersonScript;
   Rigidbody rb;
   private bool playerDie;
   LevelManager levelManager;
   SiringaScript siringaScript; 
   
  
  
 
    public void Awake(){
       switch(SceneManager.GetActiveScene().buildIndex){
           case 0:
                gecerSayi=7;
                break;
                case 1:
                gecerSayi=10;
                break;
                case 2:
                gecerSayi=15;
                break;
                default:break;

       }
        levelManager=FindObjectOfType<LevelManager>();
        levelComplete=false;
        
        rb=GetComponent<Rigidbody>();
        playerDie=false;
        levelFinish=false;
        //gecerSayi=siringa.Length/2;
        currentHealt=0;
        maxHealt=gecerSayi;
        healtBar.SetMaxHealt(maxHealt);
        boostTimer=0;
        boosting=false;
        dust=GetComponentInChildren<ParticleSystem>();
        siringaSayisi=0;
        animator=GetComponent<Animator>();
        sickPersonScript=FindObjectOfType<SickPersonScript>();
        siringaScript=FindObjectOfType<SiringaScript>();
    }
    void Start()
    {
        Debug.Log("level "+levelManager.level);
        
       
        
    }

    // Update is called once per frame
    void Update()
    {       //movement scripts
   
    if(!playerDie){
        hor=Input.GetAxis("Mouse X");
       
            if(Input.GetMouseButton(0)&&levelFinish!=true){
                startBar.SetActive(false);
                 transform.Translate(new Vector3(hor*horSpeed,0,movementSpeed*Time.deltaTime));
                animator.SetBool("walk",true);
            }else{
                animator.SetBool("walk",false);
            }
             float xPos=Mathf.Clamp(transform.position.x,-3.5f,5.5f);
        transform.position=new Vector3(xPos,transform.position.y,transform.position.z);//movement scripts
    }
            
        //boosting script
            if(boosting){
                    boostTimer+=Time.deltaTime;
                    dust.Play();
                    dust.loop=true;
                   
                    if(boostTimer>=2){
                        movementSpeed=15f;
                        boostTimer=0;
                        boosting=false;
                        dust.Stop();
                        dust.loop=false;
                    }
            }//boostin script
            if(levelFinish){
                gameObject.GetComponent<Rigidbody>().isKinematic=enabled;
                int temp=siringaSayisi;
                      if(Input.GetMouseButtonDown(0)){  
                          if(siringaSayisi>0 && levelComplete==false){
                        klon= Instantiate(bulletSiringa,nokta.position,bulletSiringa.rotation);
                        klon.GetComponent<Rigidbody>().AddForce(-klon.forward*5000f);
                          }
                            if(siringaSayisi==0&& !levelComplete){
                                 StartCoroutine(gameStop());
                                gameOverPanel.SetActive(true);
                                sickPersonScript.animator.SetBool("isDie",true);
                          }
                        
                }
            }
            //level complete kodu
            if(healtBar.slider.value==gecerSayi){
                levelFinishPanel.SetActive(true);
                sickPersonScript.Healing();
                levelComplete=true;
            }
          
            
    }
  
    private void OnCollisionEnter(Collision collision){
            if(collision.gameObject.tag=="enemy"){
            animator.SetBool("die",true);
            animator.SetBool("walk",false);
            playerDie=true;
            diePlayer();
            
           
        
            }else if(collision.gameObject.tag=="siringa"){
                Destroy(collision.gameObject);
                siringaSayisi++;
            }else if(collision.gameObject.tag=="power"){
                boosting=true;
                movementSpeed=40f;
        
               Destroy(collision.gameObject);
            }else if(collision.gameObject.tag=="FinishLevel"){
                  levelFinish=true;
                  healtBarOBJ.SetActive(true);
                gameObject.transform.position=new Vector3(0.8f,transform.position.y,transform.position.z);
              camera2.gameObject.SetActive(true);
            }
           
    }  
   
    public void Healing(int heal){ 
            currentHealt+=heal;
            healtBar.SetHealt(currentHealt);
    }
   public void diePlayer(){
      
       gameOverPanel.SetActive(true);
       StartCoroutine(gameStop());

   }
   IEnumerator gameStop(){
       yield return new WaitForSeconds(2f);   
        Time.timeScale=0f;
   }
   public void RestartGame(){
           
            Time.timeScale=1f;
            SceneManager.LoadScene(0);
    }

}
