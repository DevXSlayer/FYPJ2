using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeamCharButton : MonoBehaviour {
    private bool CharSelected = false, InTeam = false;
    private Transform OriginalTranform; //Tranform of the scrollview

    private void Start()
    {
        if (!InTeam)
            OriginalTranform = transform;
    }

    public void SelectChar()
    {
        if (!CharSelected)
        {
            if(SelectedTeam.Instance.SetCharacter(gameObject))           
                CharSelected = true;
        }
        else
        {
            if (gameObject.transform.parent != OriginalTranform)
            {
                CharSelected = false;
                gameObject.transform.SetParent(OriginalTranform);
                SelectedTeam.Instance.RemoveCharacter(gameObject);
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
