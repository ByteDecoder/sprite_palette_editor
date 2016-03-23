using UnityEngine;
using System.Collections.Generic;

[System.Serializable]
public class Palette : ScriptableObject
{
    public Texture2D sourceTexture;
    public List<Color> palette = new List<Color>();
    public List<Color> newPalette = new List<Color>();

    public Texture2D cachedTexture;

    private List<Color> GetPalette(Texture2D texture)
    {
        var palette = new List<Color>();

        var colours = texture.GetPixels();

        foreach (var c in colours)
        {
            if(!palette.Contains(c) && c.a == 1)
            {
                palette.Add(c);
            }
        }

        return palette;
    }

    public void ResetPalette()
    {
        palette = GetPalette(sourceTexture);
        newPalette = new List<Color>(palette);
    }

    public Color GetColour(Color colour)
    {
        for (int i = 0; i < palette.Count; i++)
        {
            var tmpColour = palette[i];

            if(Mathf.Approximately(colour.r, tmpColour.r) &&
                Mathf.Approximately(colour.b, tmpColour.b) &&
                Mathf.Approximately(colour.g, tmpColour.g) &&
                Mathf.Approximately(colour.a, tmpColour.a))
            {
                return newPalette[i];
            }
        }

        return colour;
    }
}
