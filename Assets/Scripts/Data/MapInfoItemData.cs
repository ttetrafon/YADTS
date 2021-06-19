using System;

[Serializable]
public class MapInfoItemData {
	public string type = "Paragraph";
	public string text = "";
	public bool playerVisible = false;

	public MapInfoItemData() { }
	public MapInfoItemData(MapInfoItemData that) {
		this.type = that.type;
		this.text = that.text;
		this.playerVisible = that.playerVisible;
	}

	public string Print() {
		return "type: '" + type + "'; text: '" + text + "'; player visible: " + playerVisible;
	}
}
