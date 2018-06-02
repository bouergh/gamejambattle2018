using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// by Logan A Lesage
public class Piston : MonoBehaviour {
    #region Variables

    public float gSize; 
    public float myInterval;
    public float myActiveTime;
    [Range(0.5f,4f)]
    public float lerpTime = 0.8f; // can be adjusted

    private float progress = 0f;
    private bool isGoingUp = true;
    private bool isWaiting = false;
    private Transform tr;
    private Vector3 minScale;
    private Vector3 maxScale;
    #endregion

    // Use this for initialization
    void Start()
    {
        tr = this.transform;
        minScale = new Vector3(1, 1, 0);
        maxScale = new Vector3(1, 1,gSize);
    }

    void Update()
    {

        #region Etat 1 : je monte (sens + si pas en Standby)

        if (!isWaiting && isGoingUp)
        {
            if (progress >= 1)
            {
                isWaiting = true;  //change pour l'etat 2 
            }
            else
            {
                progress += lerpTime * Time.deltaTime;
                tr.localScale = Vector3.Lerp(minScale, maxScale, progress);
            }
        }
        #endregion

     #region Etat 2: Arrive, wait x temps (Standby)

        if (isGoingUp && isWaiting)
        {
            Invoke("GoingDown", myActiveTime);
        }
        #endregion

        #region Etat 3: Going down down down (Sens -, si pas en Standby)

        if (!isGoingUp && !isWaiting)
        {
            if (progress <= 0)
            {
                isWaiting = true; //change pour l'etat 4
            }
            else
            {
                progress -= lerpTime * Time.deltaTime;
                tr.localScale = Vector3.Lerp(minScale, maxScale, progress);
   
            }
        }
        #endregion

        #region Etat 4: Wait, Rinse and repeat (Standby)

        if (!isGoingUp && isWaiting)
        {
            Invoke("GoingUp", myInterval);
        }
        #endregion
    }

    // Functions


    void GoingDown()
    {
        isGoingUp = false;
        isWaiting = false;
    }

    void GoingUp()
    {
        isGoingUp = true;
        isWaiting = false;
    }
}
