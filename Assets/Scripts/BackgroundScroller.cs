using UnityEngine;

public class BackgroundScroller : MonoBehaviour
{
    [SerializeField]public float scrollSpeed = 1f;
    Material bgMaterial;
    public Vector2 offSet;
    // Start is called before the first frame update
    void Start()
    {
        bgMaterial = GetComponent<Renderer>().material;
        offSet = new Vector2(scrollSpeed, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        bgMaterial.mainTextureOffset += offSet * Time.deltaTime;
    }
}
