using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnController : MonoBehaviour {
    [SerializeField]
    private GameObject enemyPrefab;
    [SerializeField]
    private float timeInterval;
    private float timeLeft;

	// Use this for initialization
	void Start () {
        timeLeft = 2.0f;
	}
	
	// Update is called once per frame
	void Update () {
        if(timeLeft>0){
            timeLeft -= Time.deltaTime;
        }
        else{
            GameObject enemy = Instantiate(enemyPrefab, this.transform.position, this.transform.rotation);
            timeLeft = timeInterval;
        }
	}
}
