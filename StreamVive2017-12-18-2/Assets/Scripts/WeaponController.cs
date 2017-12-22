using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour {
    public GameObject firePrefab;
    [SerializeField]
    public Transform firePosition;
    SteamVR_TrackedObject trackedObj;
    RaycastHit hit;
	// Use this for initialization
	void Awake () {
        trackedObj = GetComponent<SteamVR_TrackedObject>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        
        //var device = SteamVR_Controller.Input((int)trackedObj.index);
        //if ( device.GetTouchDown(SteamVR_Controller.ButtonMask.Trigger))
        //{
        //    GameObject go = GameObject.Instantiate(firePrefab);
        //    go.transform.position = firePosition.position;
        //} 

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            GameObject go = GameObject.Instantiate(firePrefab);
            go.transform.position = firePosition.position;
            go.transform.rotation = firePosition.rotation;
            if (Physics.Raycast((Vector3)firePosition.position, firePosition.forward, out hit, Mathf.Infinity)) {
                //Debug.Log(hit.collider.gameObject.name);
                if(hit.collider.gameObject){
                    hit.collider.gameObject.GetComponent<EnemyController>().Hit(1);
                }
            }
        }

	}

    private void Start()
    {

    }
}
