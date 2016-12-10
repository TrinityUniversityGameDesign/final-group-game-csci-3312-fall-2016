using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ColorPickerScript : MonoBehaviour {

	int red = 0;
	int green = 0;
	int blue = 0;
	int alpha;

	public Slider redSlider;
	public Slider blueSlider;
	public Slider greenSlider;

	public GameObject shirt;
	public GameObject player;

	public Color chc; 
	// Use this for initialization
	void Start () {
		alpha = 1;
		chc.a = alpha;
	}
	
	// Update is called once per frame
	void Update () {

		if (player != null) {
			player.GetComponent<SelectPlayerControls> ().colorPicker = this;
			shirt = player.transform.Find ("Shirt").gameObject;
		}

		if (shirt != null) {
			shirt.GetComponent<SpriteRenderer> ().color = chc;
		}

		if (redSlider != null) {
			chc.r = (redSlider.value*2)/255;
		}

		if (blueSlider != null) {
			chc.b = (blueSlider.value*2)/255;
		}

		if (greenSlider != null) {
			chc.g = (greenSlider.value*2)/255;
		}
		
		

	}
}
