using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderWeb : MonoBehaviour
{
    public float radiusPerSegment = 1f;
    public int segments = 7;

    public int sections = 8;
    float degreesPerSection { get { return 360f / sections; } }

    public Material lineMaterial;

    List<LineRenderer> lines;

    void Start()
    {
        lines = new List<LineRenderer>();

        for (int i = 0; i < sections; i++)
        {
            LineRenderer temp = new GameObject("WebSegment").AddComponent<LineRenderer>();
            temp.transform.SetParent(this.transform);
            temp.startWidth = 0.05f;
            temp.endWidth = 0.05f;
            temp.material = lineMaterial;
            temp.SetPositions(new Vector3[]
                {
                    Vector3.zero,
                    PolarToCartesian(segments * radiusPerSegment, i * degreesPerSection)
                });
        }


    }
    
    Vector2 PolarToCartesian(float r, float angle, bool radians = false)
    {
        if (!radians)
            angle = angle * Mathf.Deg2Rad;

        return new Vector2(
            Mathf.Cos(angle) * r,
            Mathf.Sin(angle) * r
            );
    }
}