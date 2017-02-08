using UnityEngine;
using System.Collections;

public class GameControl : MonoBehaviour
{
    void Start()
    {
        Config cf = new Config();
        cf.Name = "a";
        cf.Id = "1";
		XMLHelper_pcq.Analysis<Config> (cf, "C://T.xml");
         print(XMLAnalysis.SerializeXML<Config>(cf));
    }
	
	
	void Update () 
    {
		if (Input.GetMouseButtonUp (2)) {
			print (XMLHelper_pcq.ReadXML<Config> ("C://T.xml").Id);
		}
	}
}
