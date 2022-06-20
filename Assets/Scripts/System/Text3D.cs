using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Text3D : MonoBehaviour
{
    private TextMesh textMesh;
    private GameObject go;
    private float startTime;
    private bool timerEnabled;
    private float timer;
    public bool IsDisplayingText { get; private set; }


    private void CreateChildGameObject()
    {
        go = new GameObject("Text3DGameObject");
        go.transform.SetParent(gameObject.transform);
    }

    public void CreateText(string textString, float destroyTimer = -1.0f)
    {
        if (IsDisplayingText)
            Delete();

        timer = destroyTimer;
        IsDisplayingText = true;

        if (destroyTimer > 0)
        {
            startTime = Time.time;
            timerEnabled = true;
        }
        CreateChildGameObject();
        go.transform.localScale = new Vector3(0.02f, 0.02f, 0.02f);
        go.transform.localPosition = new Vector3(0, 2.0f, 0);

        textMesh = go.AddComponent<TextMesh>();
        textMesh.text = textString;
        textMesh.anchor = TextAnchor.UpperCenter;
        textMesh.alignment = TextAlignment.Center;
        textMesh.fontSize = 100;
    }

    public void Delete()
    {
        IsDisplayingText = false;
        textMesh = null;
        timerEnabled = false;
        Destroy(go);
    }


    private void Update()
    {
        if (timerEnabled)
        {
            if (Time.time > startTime + timer)
                Delete();
        }
    }
}
