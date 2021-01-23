using System;
using System.Collections;
using System.Collections.Generic;

public class MapHierarchyItem {
	public String self = "";
	public List<String> parents = new List<String>();
	public List<String> children = new List<String>();

	public MapHierarchyItem(String uuid) {
		this.self = uuid;
	}
	public MapHierarchyItem(String uuid, String parent) {
		this.self = uuid;
		this.parents.Add(parent);
	}
	public MapHierarchyItem(String uuid, List<String> parents) {
		this.self = uuid;
		this.parents = parents;
	}

}

public class MapHierarchy {
	private List<MapHierarchyItem> mapHierarchyList = new List<MapHierarchyItem>();
}
