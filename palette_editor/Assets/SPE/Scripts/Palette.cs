using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;

[System.Serializable]
public class Palette : ScriptableObject
{
    [MenuItem("Assets/Create/SPE/Palette")]
    public static void CreatePalette()
    {
        if(Selection.activeObject is Texture2D) {
            var selectedTexture = Selection.activeObject as Texture2D;

            string selectionPath = AssetDatabase.GetAssetPath(selectedTexture);
            selectionPath = selectionPath.Replace(".png", "-palette.asset");

            var newPalette = CustomAssetUtil.CreateAsset<Palette>(selectionPath);
            newPalette.sourceTexture = selectedTexture;

            newPalette.ResetPalette();

        } else {

        }
    }

    public Texture2D sourceTexture;
    public List<Color> palette = new List<Color>();
    public List<Color> newPalette = new List<Color>();

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
}
