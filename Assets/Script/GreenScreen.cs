using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GreenScreen : MonoBehaviour {

    [Header("Chroma Key")]
    public CUIColorPicker KeyColor;
    public Slider Chroma;
    public Slider ChromaT;
    public Slider Luma;
    public Slider LumaT;
    public Text txt;

    

    public Material ChromaKey;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        txt.text = Chroma.value.ToString();

        ChromaKey.SetColor("_KeyColor", KeyColor.Color);
        ChromaKey.SetFloat("_DChroma", Chroma.value);
        ChromaKey.SetFloat("_DChromaT", ChromaT.value);
        ChromaKey.SetFloat("_DLuma", Luma.value);
        ChromaKey.SetFloat("_DLumaT", LumaT.value);

        Debug.Log(KeyColor.Color);
        Debug.Log(Chroma.value);
    }
}
