using UnityEngine;

public class BlockInteraction : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        // Check for mouse click
        if (Input.GetMouseButtonDown(0))
        {
            // Cast a ray from the mouse position
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            // Check if the ray hits a collider
            if (Physics.Raycast(ray, out hit))
            {
                // Check if the hit object is a brick or question block
                if (hit.collider.CompareTag("Brick"))
                {
                    // Destroy the brick
                    Destroy(hit.collider.gameObject);
                }
                else if (hit.collider.CompareTag("Question"))
                {
                    // Increment the player's score by 100
                    GameManager.Instance.IncrementScore(100);

                    // Disable the question block
                    hit.collider.gameObject.SetActive(false);
                }
            }
        }
    }
}