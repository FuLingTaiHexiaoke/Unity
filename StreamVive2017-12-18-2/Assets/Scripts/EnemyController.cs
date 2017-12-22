using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

//open -n /Applications/Unity/Unity.app

public class EnemyController : MonoBehaviour {
    [SerializeField]
    private AudioClip enemyWakeAC;
    [SerializeField]
    private AudioClip enemyAttackAC;
    [SerializeField]
    private AudioClip enemyDeadAC;

    private Animator animator;
    private NavMeshAgent navMeshAgent;
    GameObject player;
    private float bloodCount;
	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        animator = this.GetComponent<Animator>();
        navMeshAgent= this.GetComponent<NavMeshAgent>();
     
	}
	
	// Update is called once per frame
    void FixedUpdate()
    {
        if(navMeshAgent.enabled){
            navMeshAgent.destination = player.transform.position;
            if(Vector3.Distance(gameObject.transform.position,player.transform.position)<1.5){
                SwitchAttack(true);
                navMeshAgent.isStopped=true;
                PlayAudioClip(enemyAttackAC);
            }
            else{
                SwitchAttack(false);
                navMeshAgent.isStopped = false;
                PlayAudioClip(enemyWakeAC);
            }
        }

        if(bloodCount<=0){
            AnimatorStateInfo aStateInfo = this.gameObject.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0);
            if(aStateInfo.normalizedTime>1.0f && aStateInfo.IsName("back_fall")){
                Destroy(this.gameObject);
            }
        }
	}

    public void Hit(float bloodCost){
        bloodCount -= bloodCost;
        if(bloodCount<=0){
            SwitchDead();
        }
    }

    void SwitchAttack(bool isAttacked){
        animator.SetBool("isAttack",isAttacked);
    }

    void SwitchDead()
    {
        animator.SetBool("isDead", true);
        navMeshAgent.isStopped = true;
        this.gameObject.GetComponent<CapsuleCollider>().enabled=false;
        PlayAudioClip(enemyDeadAC);
    }

    void PlayAudioClip(AudioClip ac){
        if(!this.gameObject.GetComponent<AudioSource>().isPlaying){
            this.gameObject.GetComponent<AudioSource>().clip = ac;
            this.gameObject.GetComponent<AudioSource>().Play();
        }
    }
}
