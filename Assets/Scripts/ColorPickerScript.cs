using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ColorPickerScript : MonoBehaviour {

	public int red = 0;
	public int green = 0;
	public int blue = 0;
	int alpha;

	string hexVal; 

	public Slider redSlider;
	public Slider blueSlider;
	public Slider greenSlider;
	public Button playerButton;

	public GameObject shirt;
	public GameObject player;

	public Color chc; 
	// Use this for initialization
	void Start () {
		red = (int)Mathf.Floor (chc.r * 255);
		redSlider.value = red;
		green = (int)Mathf.Floor (chc.g * 255);
		greenSlider.value = green;
		blue = (int)Mathf.Floor (chc.b * 255);
		blueSlider.value = blue;
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
			red = (int) redSlider.value;
			chc.r = (redSlider.value)/255;
		}

		if (blueSlider != null) {
			blue =(int) blueSlider.value;
			chc.b = (blueSlider.value)/255;
		}

		if (greenSlider != null) {
			green = (int) greenSlider.value;
			chc.g = (greenSlider.value)/255;
		}
		
		

	}
}
