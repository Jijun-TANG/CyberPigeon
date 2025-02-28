using UnityEngine;

public class Pipe : MonoBehaviour
{

    [SerializeField]
    private float moveSpeed = 1.0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.left * (moveSpeed * Time.deltaTime);
        
    }
}
