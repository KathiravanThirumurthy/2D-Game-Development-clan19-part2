using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Player Animation is controlled with this script
/// 1.Moving the Player left and right using the arrow keys 
/// 2.Player Jumping animation is activated via spacekey
/// 3.Using RightControl crouch animation for the palyer is created
/// Checking the player is grounded when the jump animation is done.
/// </summary>
public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private ScoreManager _scoreController;
    // speed of the Player
    [SerializeField]
    private float _speed;
    // jumpforce of the Player
    [SerializeField]
    private float _jumpForce;
    // Checking the player is grounded
    private bool isGrounded;
    // Checking for the crouch animation is happening
    private bool isCrouch;
    // Getting the Rigidbody component of the Player
    private Rigidbody2D rgd;
    // Getting the Renderer of the Player Sprite
    private SpriteRenderer sr;
    // Player Animation Script is created as a separate class which is attached to the Player 
    private PlayerAnimation _playerAnimation;
    //No. of lives
    [SerializeField]
    private int _lives;
    
    private void Awake()
    {
        // Initialising rigidbody
        rgd = GetComponent<Rigidbody2D>();
        // Getting the PlayerAnimation as a Component
        _playerAnimation = GetComponent<PlayerAnimation>();


    }
    // Start is called before the first frame update
    void Start()
    {
        // Intialising variables to check for Grounded and crouch
        isGrounded = false;
        isCrouch = false;

    }

    // Update is called once per frame
    void Update()
    {
        // Checking the for Left and Arrow keys
        float move = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Jump");
        //Calling flipPlayer method to flip the Player
        _playerAnimation.flipPlayer(move);
        // Checking for the Space bar pressed - to play jump animation
        if (Input.GetKeyDown(KeyCode.Space))
        {
           
            // Checking the player is grounded
            if (isGrounded)
            {
                //adding velocity to the player in the y direction to jump
                rgd.velocity = new Vector2(rgd.velocity.x, _jumpForce);
                // when the player is in air it Space bar shouldnt be pressed 
                isGrounded = false;
                // calling the jumping method from the PlayerAnimation Script
                _playerAnimation.jumping(true);
            }
        }
        // Checking for the RightControl pressed - to play the crouch animation
        if(Input.GetKeyDown(KeyCode.RightControl))
        {
            // setting the value to true to confirm Control is pressed
                  isCrouch = true;
            // calling the crouching method from the PlayerAnimation Script
                 _playerAnimation.crouching(isCrouch);   
        }
        // Checking for the RightControl key is notpressed - to stop the crouch animation
        if (Input.GetKeyUp(KeyCode.RightControl))
        {
            // setting the value to false to confirm Control is not pressed
            isCrouch = false;
            // calling the crouching method from the PlayerAnimation Script by passing the current value
            _playerAnimation.crouching(isCrouch);
        }
        // to check playermovement is possible only when the Crouch animation is not playing
        if(!isCrouch)
        {
            // moving the player using velocity with speed
            rgd.velocity = new Vector2(move * _speed, rgd.velocity.y);
            // calling the movment method from the PlayerAnimation Script to move the player
            _playerAnimation.movement(move);
        }
        
    }

    // checking the player for collision with the platform
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // if the player collides with Ground with tag "Platform"
        if (collision.gameObject.tag == "Platform")
        {
            // to check Grounded
            isGrounded = true;
            // calling the jumping method from the PlayerAnimation Script to jump
            _playerAnimation.jumping(false);
        }else if(collision.gameObject.tag == "Deathline")
        {
            Debug.Log("Dead");
            _playerAnimation.playerDead(true);
        }

    }

    public void pickUpKey(int score)
    {
       // Debug.Log("Score:" + score);
        _scoreController.incrementScore(score);
    }

    public void playerDead(bool playerState)
    {
        Debug.Log("Player was hit");
        //_playerAnimation.playerDead(playerState);
        Damage();
    }

    public void Damage()
    {
        
        _lives--;
        UIManager.instance.UpdateLives(_lives);

        if (_lives < 0)
        {

            Debug.Log("Player Killed by the EnemyChomper ");
            UIManager.instance.UpdateLives(_lives);
        }
        else if ( _lives == 0)
        {
            
            _playerAnimation.playerDead(true);
            UIManager.instance.restartCurrentScene();
            Debug.Log("Remaining Lives : " + _lives);
        }

    }







}
