using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement; // Include this to use SceneManager

public class LIZScript : MonoBehaviour
{
    public Rigidbody2D myRigidbody;
    public float flapStrength;
    public float dashStrength;
    public float hoverSpeed = 2f; // Speed at which the character hovers back to the center
    public LogicScript logic;
    public bool LizLives = true;

    public AudioClip BGM; // Background music for the game
    public AudioClip flapSound;   // Sound effect for the flap
    public AudioClip dashSound;   // Sound effect for the dash
    private AudioSource audioSource;

    private bool isHovering = false; // Track if the character is hovering back to the center

    // Start is called before the first frame update
    void Start()
    {
        gameObject.name = "LIZ LEE";
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
        audioSource = GetComponent<AudioSource>(); // Get the AudioSource component

        // Play background music and set it to loop
        audioSource.clip = BGM;
        audioSource.loop = true;
        audioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && LizLives)
        {
            myRigidbody.velocity = Vector2.up * flapStrength;
            PlaySound(flapSound); // Play flap sound
        }
        if (Input.GetKeyDown(KeyCode.LeftShift) && LizLives && !isHovering)
        {
            myRigidbody.velocity = Vector2.right * dashStrength;
            PlaySound(dashSound); // Play dash sound
            StartCoroutine(HoverBackToCenter());
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        logic.gameOver();
        LizLives = false;
        StartCoroutine(RestartGame()); // Start the restart game process
    }

    private IEnumerator HoverBackToCenter()
    {
        isHovering = true;
        while (Mathf.Abs(transform.position.x) > 0.1f)
        {
            // Gradually move the character back towards the center
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(0, transform.position.y), hoverSpeed * Time.deltaTime);
            yield return null;
        }
        isHovering = false;
    }

    private void PlaySound(AudioClip clip)
    {
        audioSource.PlayOneShot(clip); // Play the given sound effect
    }

    private IEnumerator RestartGame()
    {
        yield return new WaitForSeconds(2); // Wait for 2 seconds before restarting the game
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Reload the current scene
    }
}
