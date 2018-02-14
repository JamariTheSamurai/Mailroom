using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buckets : MonoBehaviour
{

    public bool virusOrNah;
    public SoundManager soundManager;

    // BasicMail
    // LoveMail
    // VirusMail
    // SpyMail
    // SpamMail

    public enum BucketTypes { Basic, Trash, Spy, Love, Other } ;

    public BucketTypes types;

    private void OnTriggerEnter(Collider other)
    {
        string package = other.tag;
        if(other.tag == "SpamMail" && (types == BucketTypes.Trash))
        {
            virusOrNah = false;
        }
        else if (other.tag == "VirusMail" && (types == BucketTypes.Trash))
        {
            virusOrNah = true;
        }

        if (package == ReportBucketType(types)) 
        {
            SuckPackage(other.gameObject);
           
            soundManager.PlaySuccess();
            soundManager.SendMessage("MailDropped", package);
        }
        else if(other.tag == "Player")
        {
            
        }
        else
        {
            SuckPackage(other.gameObject);
            soundManager.PlayFailure();
            soundManager.SendMessage("WrongBox", package);
        }
    }

    string ReportBucketType (BucketTypes st)
    {
        string msg = "";

        if (types == BucketTypes.Spy)
        {
            msg = "SpyMail";
        }
        else if (types == BucketTypes.Trash)
        {
            if (virusOrNah)
            {
                msg = "VirusMail";
            }
            else
            {
                 msg = "SpamMail";
            }
        }
        else if (types == BucketTypes.Basic)
        {
            msg = "BasicMail";
        }
        else if (types == BucketTypes.Love)
        {
            msg = "LoveMail";
        }

        return msg;
    }

    void SuckPackage (GameObject go)
    {
        go.GetComponent<Rigidbody>().velocity = new Vector3(0f, 5f, 0f);

        StartCoroutine(DestroyThisPackage(go));
    }

    IEnumerator DestroyThisPackage(GameObject go)
    {
        MeshRenderer mr = go.GetComponent<MeshRenderer>();
        for (float f = 1f; f >= 0; f -= 0.1f)
        {
            Color c = mr.material.color;
            c.a = f;
            mr.material.color = c;
        }

        Destroy(go);

        yield return null;
    }
}