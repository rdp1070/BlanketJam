using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmailObject{


    public string subject;
    public string message;
    public string replyText;
    public bool replied = false;
    public Sprite avatar;
    int index;

    private ComputerManager owner;

    public void Init(string sub, string mes, string rep, int i, Sprite a, ComputerManager o)
    {
        subject = sub;
        message = mes;
        replyText = rep;
        avatar = a;
        index = i;
        owner = o;
    }
}
