using UnityEngine;

public class parallaxEffect : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float shiftSpeed = 0.0001f; // Speed of scrolling

    [SerializeField]
    private GameObject background;
    private Material mapMaterial;
    public float parallaxOffset = 0.0f; // How much the background moves in relation to the camera



    void Start()
    {
        // Store the initial position of the image
        background = GameObject.FindGameObjectWithTag("Background"); 
        mapMaterial = background.GetComponent<Renderer>().material;
    }

    void Update()
    {
        parallaxOffset += shiftSpeed * Time.deltaTime;
        mapMaterial.SetTextureOffset("_MainTex", new Vector2(parallaxOffset, 0));  //.mainTextureOffset += new Vector2(scrollSpeed * Time.deltaTime, 0);
        
    }
}
