using UnityEngine;
using System.Collections;

public class Shooting : MonoBehaviour {

	public int bulletSpeed = 10;
	public GameObject bullet;
	public Transform gun;
//	public Rigidbody clone;
//	public Transform myTransform;

//	bool facingRight;

	void Start ()
	{
//		facingRight = true;
	}
	
	void Update () 
	{
		// if (Input.GetKeyDown (KeyCode.LeftArrow)) 
		// {
		// 	facingRight = false;
		// } 
		// else if (Input.GetKeyDown (KeyCode.RightArrow)) 
		// {
		// 	facingRight = true;
		// }


		if(Input.GetKeyDown(KeyCode.F))
		{
			var newBullet = Instantiate(bullet, gun.transform.position, gun.transform.rotation);
			newBullet.GetComponent<Rigidbody>().velocity = transform.TransformDirection(gun.transform.forward * bulletSpeed);
		} 
//		else if (!facingRight && (Input.GetKeyDown(KeyCode.RightShift)))//Fire Button
//			clone = Instantiate(clone, transform.position, transform.rotation) as Rigidbody;
//			clone.rigidbody.velocity = transform.TransformDirection(Vector3.left * 10);

		
	}

}



	






