using UnityEngine;

public class NPCMovement : MonoBehaviour
{
    public float speed = 5000;
    void Update()
    {
        // Bergerak ke depan dengan kecepatan tertentu
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
}
