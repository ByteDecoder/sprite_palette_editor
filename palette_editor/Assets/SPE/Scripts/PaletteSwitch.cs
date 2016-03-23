using UnityEngine;

public class PaletteSwitch : MonoBehaviour {

    public Palette[] palettes;

    private SpriteRenderer spritRenderer;
    private Texture2D texture;
    private MaterialPropertyBlock block;

    void Awake()
    {
        spritRenderer = GetComponent<SpriteRenderer>();
    }
    
	void Start ()
    {
        if(palettes.Length > 0)
             SwapColours(palettes[Random.Range(0, palettes.Length)]);
	}

    void LateUpdate()
    {
        spritRenderer.SetPropertyBlock(block);
    }

    private void SwapColours(Palette palette)
    {
        if (palette == null)
        {
            Debug.LogError("Null Palette");
            return;
        }

        if (palette.cachedTexture == null)
        {
            texture = spritRenderer.sprite.texture;

            var cloneTexture = new Texture2D(texture.width, texture.height);
            cloneTexture.wrapMode = TextureWrapMode.Clamp;
            cloneTexture.filterMode = FilterMode.Point;

            var colours = texture.GetPixels();

            for (int i = 0; i < colours.Length; i++)
            {
                colours[i] = palette.GetColour(colours[i]);
            }

            cloneTexture.SetPixels(colours);
            cloneTexture.Apply();

            palette.cachedTexture = cloneTexture;
        }

      

        block = new MaterialPropertyBlock();
        block.SetTexture("_MainTex", palette.cachedTexture);

    }
}
