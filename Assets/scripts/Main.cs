using UnityEngine;
using System.Collections;
using UnityEditor;

public class Main : MonoBehaviour {
	private GameObject _snakey;
	// Use this for initialization
	
	private const float speed = 0.07f;
	void Start () {
		_snakey = GameObject.Find("snakey");
		print (AssetDatabase.GetAssetPath(_snakey.GetComponent<SpriteRenderer>().sprite));
		CreateFruits();
	}
	
	void OnCollisionEnter2D(Collision2D col) {
		if (col.gameObject.name == "apple"
		    || col.gameObject.name == "orange") {
		    	Destroy(col.gameObject);
		    }
	}
	
	void Move () {
		float dX = 0, dY = 0;
		
		if (Input.GetKey(KeyCode.UpArrow)) {
			dY += speed;
		}
		if (Input.GetKey(KeyCode.DownArrow)) {
			dY -= speed;
			/*Vector3 angle = snakey.transform.eulerAngles;
			snakey.transform.eulerAngles = new Vector3(0, 0, 90);
			snakey.transform.position =
				new Vector3(snakey.transform.localPosition.x,
				snakey.transform.localPosition.y - speed, 0);*/
		}
		if (Input.GetKey(KeyCode.LeftArrow)) {
			dX -= speed;
		}
		if (Input.GetKey(KeyCode.RightArrow)) {
			dX += speed;
		}

		Vector3 oldPos = _snakey.transform.localPosition;
		Vector3 newPos = new Vector3(oldPos.x + dX, oldPos.y + dY, 0);
		Vector3 moveDirection = newPos - oldPos;
		
		if (moveDirection != Vector3.zero) {
			
			float angle = Mathf.Atan2(moveDirection.y, moveDirection.x) * Mathf.Rad2Deg;
			
			_snakey.transform.rotation = Quaternion.AngleAxis(180 + angle, Vector3.forward);
			_snakey.transform.localPosition = newPos;
		}
	}
	
	void CreateFruits () {
		GameObject obj = new GameObject("fruit");
		Object tmp = Resources.Load("sprites/apple.png");
		if (tmp == null) print ("No such sprite fruit");
		AssetBundle.CreateFromFile(
		//obj.AddComponent<SpriteRenderer>().sprite = tmp;
		//Instantiate(obj, new Vector3(3, -3, 0), Quaternion.identity);
	}
	
	// Update is called once per frame
	void Update () {
		Move();
		
		
	}
}
