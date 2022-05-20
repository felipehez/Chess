using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

[ExecuteInEditMode]
public class Parser : MonoBehaviour
{
    private string fileToParse = "";

    public string filePath = "filePath";
    public string fileName = "fileName";
    public string fileExtension = "txt";

    public int headersLineNumber = 0;
    public int valuesFromLine = 1;

    // Start is called before the first frame update
    void Awake()
    {
        fileToParse = filePath;
        fileToParse = Path.Combine(fileToParse, fileName);
        fileToParse = fileToParse + "." + fileExtension;

        FileInfo theSourceFile = null;
        TextReader reader = null;  // NOTE: TextReader, superclass of StreamReader and StringReader

        theSourceFile = new FileInfo(Path.Combine(Application.dataPath, fileToParse));
        if (theSourceFile != null && theSourceFile.Exists)
        {
            reader = theSourceFile.OpenText();  // returns StreamReader
            Debug.Log("Created Stream Reader for " + fileToParse + " (in Datapath)");
        }

        if (reader == null)
        {
            Debug.Log(fileName + " not found or not readable");
        }
        else
        {
            // Read each line from the file/resource
            bool goOn = true;
            int lineCounter = 0;            
            string[] headers = new string[0];
            while (goOn)
            {
                string BufLine = reader.ReadLine();
                if (BufLine == null)
                {
                    goOn = false;
                    return;
                }
                else
                {
                    //Debug.Log("Current Line : " + lineCounter + " : " + buf);

                    string[] values;
                    
                    if (lineCounter == headersLineNumber)
                    {
                        headers = BufLine.Split(';');
                        //Debug.Log("--> Found header " + headers[0]);
                    }
                    if (lineCounter >= valuesFromLine)
                    {
                        // now we get a , ; or -delimited string with data
                        // ID ...
                        values = BufLine.Split(';');
                        string ID = values[0];                        
                        //Debug.Log("--> Found values " + values[0]);

                        GameObject go = null;
                        //go = GameObject.Find(ID);                       

                        //if (go == null)
                            {
                                foreach (var gameObj in
                                 FindObjectsOfType(typeof(GameObject)) as GameObject[])
                                {
                                    if (gameObj.name.Contains(ID.ToString()))
                                    {
                                        go = gameObj;                                    
                                    }
                                }
                            }
                        
                        if (go != null)
                        {
                            //Debug.Log("    Found ID : " + ID);
                            if (go.GetComponent<Metadata>() == null)    // checkea que no exista un comp Meta en el obj
                            {
                                go.AddComponent<Metadata>();
                                Metadata meta = go.GetComponent<Metadata>();
                                meta.values = values;
                                meta.keys = headers;
                            }                            
                        }
                        else
                        {
                            //Debug.Log("    No objects found with ID: " + ID);
                        }
                    }
                }

                lineCounter++;
            }
        }
    }
}



