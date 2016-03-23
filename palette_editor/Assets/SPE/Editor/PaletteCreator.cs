using UnityEngine;
using UnityEditor;

public class PaletteCreator : MonoBehaviour {

    [MenuItem("Assets/Create/SPE/Palette")]
    public static void CreatePalette()
    {
        if (Selection.activeObject is Texture2D)
        {
            var selectedTexture = Selection.activeObject as Texture2D;

            string selectionPath = AssetDatabase.GetAssetPath(selectedTexture);
            selectionPath = selectionPath.Replace(".png", "-palette.asset");

            var newPalette = CustomAssetFactory.CreateAsset<Palette>(selectionPath);
            newPalette.sourceTexture = selectedTexture;

            newPalette.ResetPalette();

        }
        else {

        }
    }
}
