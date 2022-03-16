using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

public class NoiceGenerator : MonoBehaviour
{
    [SerializeField] private int width, height = 512;
    [SerializeField] private float xOrigin, yOrigin;
    [SerializeField] private float scale = 10f;

    private Texture2D noiceTexture;
    private Color[] pix;
    private Renderer rend;

    private void Start()
    {
        rend = GetComponent<Renderer>();
        noiceTexture = new Texture2D(width, height);
        pix = new Color[noiceTexture.width * noiceTexture.height];
        rend.material.mainTexture = noiceTexture;
    }

    private void Update()
    {
        CalculateNoise();
    }

    private void CalculateNoise()
    {
        var y = 0f;
        while (y<noiceTexture.height)
        {
            var x = 0f;
            while (x<noiceTexture.width)
            {
                var xCoord = xOrigin + x / noiceTexture.width * scale;
                var yCoord = yOrigin +y / noiceTexture.height * scale;
                var sample = Mathf.PerlinNoise(xCoord, yCoord);
                pix[(int) y * noiceTexture.width + (int) x] = new Color(sample, sample, sample);
                x++;
            }
            
            y++;
        }
        
        noiceTexture.SetPixels(pix);
        noiceTexture.Apply();
    }

#if UNITY_EDITOR
    
    [ContextMenu("Save")]
    private void SaveTexture()
    {
        var bytes = noiceTexture.EncodeToPNG();

        var path = Path.Combine(Application.dataPath, "Textures");
        Debug.Log(path);
        path = Path.Combine(path, "test.png");
        if (!Directory.Exists(Path.GetDirectoryName(path)))
        {
            Directory.CreateDirectory(Path.GetDirectoryName(path) ?? string.Empty);
        }
        
        File.WriteAllBytes(path,bytes);
        AssetDatabase.Refresh();
    }
    
#endif
}
