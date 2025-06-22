using UnityEngine;

public class MenuWalker : MonoBehaviour
{
    public float walkSpeed = 2.5f;
    public float resetX = -3f;
    public float maxX = 13f;

    // Update is called once per frame
    void Update()
    {
        // Move right 
        transform.Translate(Vector2.right * walkSpeed * Time.deltaTime);

        // Reset to left if offscreen
        if (transform.position.x > maxX)
        {
            Vector3 resetPosition = transform.position;
            resetPosition.x = resetX;
            transform.position = resetPosition;
        }
    }
}
