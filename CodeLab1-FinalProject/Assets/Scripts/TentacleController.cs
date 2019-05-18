using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

public class TentacleController : MonoBehaviour
{
    // line renderer
    public LineRenderer tentacleLine;

    public Vector3 tentacleTip;
    public Vector3 tentacleMid;
    public Vector3 tentacleBase;
    private Vector3 midVel;

    public float moveSpeed = 1f;
    public float drag = 0.025f;

    public float hangAmount = 3f; // how much the tentacle droops
    public float midOffset = .7f;
    public float smoothAmount = .025f;

    public Transform baseTransform;
    public Transform tipTransform;
    
    // Start is called before the first frame update
    void Start()
    {
        tentacleLine = GetComponent<LineRenderer>();
        tentacleMid = transform.position;
    }

    void UpdateLine(Vector3 lineBase, Vector3 lineTip)
    {
        tentacleTip = lineTip;
        tentacleBase = lineBase;

        // finding a point between tip and base (dependent on midOffset) and makes it hang down
        Vector3 targetMid = Vector3.Lerp(lineTip, lineBase, midOffset) + hangAmount * Vector3.down;
        midVel = Vector3.Lerp(midVel, targetMid - tentacleMid, smoothAmount);
        
        tentacleMid += midVel * moveSpeed; // how fast the tentacle should move
        midVel *= 1f - drag; // decrease midVel like a spring

        Vector3 a = tentacleBase;
        Vector3 b = tentacleMid;
        Vector3 c = tentacleTip;
        
        // iterate every point in the line and updating their positions, lerping to make wobbly line
        float step = 1f / (tentacleLine.positionCount - 1f); // distance between the points in the line; -1f so that tip isn't smoothed out
        for (int i =0; i < tentacleLine.positionCount; i++)
        {
            float f = step * i; // how far along the line we're in; the point we're in
            Vector3 currentPoint = Vector3.Lerp(Vector3.Lerp(a, b, f), Vector3.Lerp(b, c, f), f);
                // first lerp (a, b, f) --> point between base and mid
                // second lerp (b, c, f) --> point between mid to tip
                // lerping between the 2 above points; bezier curve
            tentacleLine.SetPosition(i, currentPoint);
        }
    }

    // Update is called once per frame
    void Update()
    {
        UpdateLine(baseTransform.position, tipTransform.position);
    }
}
