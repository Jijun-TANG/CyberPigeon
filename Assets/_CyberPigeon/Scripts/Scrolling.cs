using UnityEngine;

public class Scrolling : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float scrollSpeed = 0.0001f; // Speed of scrolling

    private Vector2 startPosition;

    [SerializeField]
    private Transform camera;
    private Vector3 cameraPosition;
    float cameraTraveledDistance;

    private GameObject background;
    private Material mapMaterial;
    public float parallaxEffect = 0.0f; // How much the background moves in relation to the camera



    void Start()
    {
        // Store the initial position of the image
        background = GameObject.FindGameObjectWithTag("Background"); 
        mapMaterial = background.GetComponent<Renderer>().material;
    }

    void Update()
    {
        parallaxEffect += scrollSpeed * Time.deltaTime;
        mapMaterial.SetTextureOffset("_MainTex", new Vector2(parallaxEffect, 0));  //.mainTextureOffset += new Vector2(scrollSpeed * Time.deltaTime, 0);
        
    }

    
}
