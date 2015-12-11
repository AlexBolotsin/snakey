using UnityEngine;
using System.Collections;

public class Main : MonoBehaviour {
	private GameObject _snakey;
	public GameObject apple;
	// Use this for initialization
	
	private const float speed = 0.07f;
	void Start () {
		_snakey = GameObject.Find("snakey");
		CreateFruits();
	}
	
	void OnCollisionEnter2D(Collision2D col) {
		if (col.gameObject.name.Contains("apple")
		    || col.gameObject.name.Contains("orange")
		    || col.gameObject.name.Contains("fruit")) {
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
		obj.transform.localPosition = new Vector3(-2.5f, -4.0f, 0);
		
		obj.AddComponent<SpriteRenderer>().sprite =
			Resources.Load<Sprite>("sprites/orange");
		obj.AddComponent<PolygonCollider2D>();
		Instantiate(obj, new Vector3(3, -3, 0), Quaternion.identity);

		Instantiate (GameObject.Find ("apple"), new Vector3(3, 3, 0), Quaternion.identity);
		Instantiate (Resources.Load("apple"), new Vector3(3, 1, 0), Quaternion.identity);
		Instantiate (apple, new Vector3(-2, 5, 0), Quaternion.identity);
	}
	
	// Update is called once per frame
	void Update () {
		Move();
		
	}
}
