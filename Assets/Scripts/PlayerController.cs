using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerController : MonoBehaviour
{

	// Create public variables for player speed, and for the Text UI game objects
	public float speed;
	public TextMeshProUGUI countText;
	public GameObject winTextObject;


	private float movementX;
	private float movementY;

	private Rigidbody rb;
	private int count;

	public int lives = 3;

	public Transform respawnPoint;

	public FixedJoystick joystick;
	
	// At the start of the game..
	void Start()
	{
		// Assign the Rigidbody component to our private rb variable
		rb = GetComponent<Rigidbody>();

		// Set the count to zero 
		count = 0;

		SetCountText();

		// Set the text property of the Win Text UI to an empty string, making the 'You Win' (game over message) blank
		winTextObject.SetActive(false);
	}

	void FixedUpdate()
	{
		// Create a Vector3 variable, and assign X and Z to feature the horizontal and vertical float variables above
		Vector3 movement = new Vector3(joystick.Horizontal *speed, 0.0f,joystick.Vertical * speed);
		
		rb.AddForce(movement * speed);
	}

	void OnTriggerEnter(Collider other)
	{
		// ..and if the GameObject you intersect has the tag 'Pick Up' assigned to it..
		if (other.gameObject.CompareTag("PickUp"))
		{
			other.gameObject.SetActive(false);

			// Add one to the score variable 'count'
			count = count + 1;

			// Run the 'SetCountText()' function (see below)
			SetCountText();
		}
		
		if (other.gameObject.CompareTag("Enemy"))
        {
			other.gameObject.SetActive(true);
        }
		
	}
    void OnMove(InputValue value)
	{
		Vector2 v = value.Get<Vector2>();

		movementX = v.x;
		movementY = v.y;
	}

	void SetCountText()
	{
		countText.text = "Count: " + count.ToString();

		if (count >= 12)
		{
			// Set the text value of your 'winText'
			winTextObject.SetActive(true);
		}
	}
	public void Damage()
	{
		lives -= 1;
		if (lives < 1)
        {
		
		RespawnPlayer();
		}
		
	}
	private void RespawnPlayer()
    {
		transform.position = respawnPoint.position;
    }
}


