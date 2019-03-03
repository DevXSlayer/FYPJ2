using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeamCharButton : MonoBehaviour {
    private bool CharSelected = false, InTeam = false;
    private Transform OriginalTranform; //Tranform of the scrollview
    public TeamCharSelect CharSelect; //Accessing SetChar and RemoveChar functions

    private void Start()
    {
        if (!InTeam)
            OriginalTranform = transform.parent;
        Debug.Log(CharSelected);
    }

    public void SelectChar()
    {
        if (!CharSelected)
        {
            if(CharSelect.SetCharacter(gameObject))          
                CharSelected = true;
        }
        else
        {
            if (gameObject.transform.parent != OriginalTranform)
            {
                CharSelected = false;
                gameObject.transform.SetParent(OriginalTranform);
                CharSelect.RemoveCharacter(gameObject);
            }
        }
    }

    public void SetInTeam(Transform parent)
    {
        OriginalTranform = parent;
        InTeam = true;
        CharSelected = true;
    }
}
