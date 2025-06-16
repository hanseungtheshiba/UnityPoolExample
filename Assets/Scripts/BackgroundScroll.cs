using UnityEngine;

public class BackgroundScroll : MonoBehaviour
{
    [SerializeField]
    private float scrollSpeed = 0.2f;
    private MeshRenderer meshRenderer = null;
    private Vector2 offset = Vector2.zero;
    
    private void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    private void Update()
    {
        offset += new Vector2(scrollSpeed * Time.deltaTime, 0f);
        meshRenderer.material.SetTextureOffset("_MainTex", offset);
    }
}
