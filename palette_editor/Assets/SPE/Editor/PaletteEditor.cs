﻿using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof(Palette))]
public class PaletteEditor : Editor
{
    private Palette palette;

    void OnEnable()
    {
        palette = target as Palette;
    }

    public override void OnInspectorGUI()
    {
        GUILayout.Label("Source Texture");

        palette.sourceTexture = EditorGUILayout.ObjectField(palette.sourceTexture, typeof(Texture2D), false) as Texture2D;

        EditorGUILayout.BeginHorizontal();

        GUILayout.Label("Current Colour");
        GUILayout.Label("New Colour");


        EditorGUILayout.EndHorizontal();

        for (var i = 0; i < palette.palette.Count; i++)
        {
            EditorGUILayout.BeginHorizontal();

            EditorGUILayout.ColorField(palette.palette[i]);
            palette.newPalette[i] = EditorGUILayout.ColorField(palette.newPalette[i]);

            EditorGUILayout.EndHorizontal();
        }


    }

}