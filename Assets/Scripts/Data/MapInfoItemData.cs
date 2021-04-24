using System;

[Serializable]
public class MapInfoItemData {
	public string type = "Paragraph";
	public string text = "";
	public bool playerVisibile = false;

	public MapInfoItemData() { }
	public MapInfoItemData(MapInfoItemData that) {
		this.type = that.type;
		this.text = that.text;
		this.playerVisibile = that.playerVisibile;
	}

	public string Print() {
		return "type: '" + type + "'; text: '" + text + "'; player visible: " + playerVisibile;
	}
}
