using UnityEngine;
using System.Collections;

public class Bouncy : MonoBehaviour {
	private bool bouncing;
	private float cooldown;

	void Start () {
		bouncing = false;
	}
	//当棋子被选中的时候会被调用
	public void bounce(){
        if (!bouncing)
        {
            bouncing = true;
            cooldown = Time.realtimeSinceStartup;
        }

	}
	
	public void stopBounce(){
		bouncing = false;
	}

	void Update () {
		if (!bouncing){
            gameObject.transform.position = new Vector3(gameObject.transform.position.x, 0.1f, gameObject.transform.position.z);
            gameObject.transform.localScale = new Vector3(0.7f,0.05f,0.7f);
        }
			
		else{
			if((Time.realtimeSinceStartup - cooldown) % 1f < 0.5f){
                gameObject.transform.localScale = new Vector3(gameObject.transform.localScale.x + (0.2f * Time.deltaTime), gameObject.transform.localScale.y, gameObject.transform.localScale.z + (0.2f * Time.deltaTime));
				//gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y+(0.2f*Time.deltaTime), gameObject.transform.position.z);
			}else{
                gameObject.transform.localScale = new Vector3(gameObject.transform.localScale.x - (0.2f * Time.deltaTime), gameObject.transform.localScale.y, gameObject.transform.localScale.z - (0.2f * Time.deltaTime));
				//gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y-(0.2f*Time.deltaTime), gameObject.transform.position.z);
			}
		}
	}
}
