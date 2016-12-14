using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class Movement : MonoBehaviour {

    //movement variables
    private float moveX;
    private float moveY;

	private TestScript testScript;
    

    Animator animate;
    public float moveSpeed;
	public string playerName; 
    public GameObject player;

    void Start(){
        animate = GetComponent<Animator>();

    }
	
	// Update is called once per frame
	void FixedUpdate () {
		
        moveX = Input.GetAxis("Horizontal");
        moveY = Input.GetAxis("Vertical");

		//Sets animator values for 'speed' and 'speedY' [to detect motion]
		animate.SetFloat ("speed", Mathf.Abs (moveX));
		animate.SetFloat ("speedY", Mathf.Abs (moveY));

        GetComponent<Rigidbody2D>().velocity = new Vector2(moveX * moveSpeed, moveY * moveSpeed);

		//Animation for left/right
		if (moveX > 0)
			animate.SetBool ("toRight", true);
		else if (moveX < 0)
			animate.SetBool ("toRight", false);

		//Animation for up/down
		if (moveY > 0)
			animate.SetBool ("toUp", true);
		else if (moveY < 0)
			animate.SetBool ("toUp", false);
    }
}
