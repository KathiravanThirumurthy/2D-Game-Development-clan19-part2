using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Player Controller script access this script
/// all types of movment related scripts are done
/// </summary>
public class PlayerAnimation : MonoBehaviour
{
    private Animator anim;
    private void Awake()
    {
        //anim = GetComponentInChildren<Animator>();
        anim = GetComponent<Animator>();
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    // player movement method implementation
    public void movement(float move)
    {
      // making the animation to play for movement i.e idle to walk and Run
      anim.SetFloat("speed", Mathf.Abs(move));
    }
    // player crouching method implementation
    public void crouching(bool crouch)
    {
        // checking for the crouching animation with SetBool method in the Animator panel
        anim.SetBool("isCrouch", crouch);
    }
    public void jumping(bool jump)
    {
        // checking for the jumping animation with SetBool method in the Animator panel
        anim.SetBool("isJump", jump);
    }

    // flipping the player depending on the keypresses
    public void flipPlayer(float speed)
    {
        // getting the localScale of the Player
        Vector2 scale = transform.localScale;
        // when the speed is negative multiplyig the scale value with (-ve values) to flip the scale and  vice versa
        if (speed < 0) scale.x = -1.0f * Mathf.Abs(scale.x);
        else if (speed > 0) scale.x = Mathf.Abs(scale.x);
        //setting scale to the localScale of the Player
        transform.localScale = scale; 
    }

    public void playerDead(bool dead)
    {
        anim.SetBool("isDead", dead);
    }
}
