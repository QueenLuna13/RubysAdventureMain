using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NonPlayerCharacter : MonoBehaviour

{
    public float displayTime = 4.0f;
    public GameObject dialogBox;
    public Transform player;
    public float interactionDistance = 3.0f;

    private float timerDisplay;
    private int currentDialogIndex = 0;

    // List of dialog texts
    public string[] dialogTexts = {
        "Hello, adventurer!",
        "Welcome to my shop.",
        "Have a great day!"
    };

    void Start()
    {
        dialogBox.SetActive(false);
        timerDisplay = -1.0f;

        if (player == null)
        {
            // If player is not set, assume it's the main camera
            player = Camera.main.transform;
        }
    }

    void Update()
    {
        // Check if the player is facing the NPC and within interaction distance
        bool isPlayerFacingNPC = IsPlayerFacingNPC();
        bool isPlayerInRange = Vector3.Distance(transform.position, player.position) <= interactionDistance;

        // Check if the 'X' key is pressed
        if ((isPlayerFacingNPC && isPlayerInRange && Input.GetKeyDown(KeyCode.X)) || Input.GetKeyDown(KeyCode.X))
        {
            // Call DisplayDialog when facing the NPC or simply pressing 'X'
            DisplayDialog();
        }

        // Check if the timer is running
        if (timerDisplay >= 0)
        {
            // Decrease the timer
            timerDisplay -= Time.deltaTime;

            // Check if the timer has reached zero
            if (timerDisplay < 0)
            {
                // Hide the dialog box when the timer reaches zero
                dialogBox.SetActive(false);
            }
        }
    }

    bool IsPlayerFacingNPC()
    {
        Vector3 directionToNPC = transform.position - player.position;
        float dotProduct = Vector3.Dot(player.forward, directionToNPC.normalized);

        // You can adjust this threshold value based on your needs
        return dotProduct > 0.5f;
    }

    public void DisplayDialog()
    {
        // Only reset the timer if the dialog box is not already active
        if (!dialogBox.activeSelf)
        {
            // Increment the dialog index and wrap around if it exceeds the array length
            currentDialogIndex = (currentDialogIndex + 1) % dialogTexts.Length;

            // Set the current dialog text
            SetDialogText(dialogTexts[currentDialogIndex]);

            // Toggle the dialog box's visibility
            dialogBox.SetActive(true);

            // Reset the timer
            timerDisplay = displayTime;
        }
    }

    void SetDialogText(string text)
    {
        // Set the text of your dialog box UI element here
        // For example, if using Text component, you can do something like:
        // dialogBox.GetComponent<Text>().text = text;
        // Replace the line above with the appropriate code based on your UI setup.
    }
}
