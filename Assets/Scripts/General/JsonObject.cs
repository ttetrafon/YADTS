using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using UnityEngine;

public class JsonObject {
	///////////////////
	///   ENCODER   ///
	///////////////////
	public static string ToJson(object obj, int level = 1, bool debug = false) {
		if (debug) { Debug.Log("---> ToJson()"); }
		string json = "{\n";
		FieldInfo[] properties = obj.GetType().GetFields();
		int len = properties.Length, i = 1;
		if (debug) { Debug.Log("number of properties: " + len.ToString()); }
		foreach ( FieldInfo property in properties ) {
			if (debug) { Debug.Log("----- V ----- V -----\n" + property.Name + " is a " + property.FieldType.ToString()); }
			// PRIMITIVES
			if (property.FieldType == typeof(System.Int32)) {
				json += Add_Int(property.Name, (int)property.GetValue(obj), level, i == len);
			}
			else if (property.FieldType == typeof(System.Single)) {
				json += Add_Float(property.Name, (float)property.GetValue(obj), level, i == len);
			}
			else if (property.FieldType == typeof(System.String)) {
				json += Add_String(property.Name, property.GetValue(obj).ToString(), level, i == len);
			}
			else if (property.FieldType == typeof(System.Boolean)) {
				json += Add_Boolean(property.Name, (bool)property.GetValue(obj), level, i == len);
			}
			// CUSTOM OBJECTSd
			// ARRAYS
			else if (property.FieldType == typeof( System.Int32[])) {
				json += Add_IntArray(property.Name, (int[])property.GetValue(obj), level, i == len);
			}
			else if (property.FieldType == typeof(System.String[] ) ) {
				json += Add_StringArray(property.Name, (string[])property.GetValue(obj), level, i == len, debug);
			}
			// LISTS
			else if (property.FieldType == typeof(System.Collections.Generic.List<System.Int32>)) {
				json += Add_IntList(property.Name, (List<int>)property.GetValue(obj), level, i == len);
			}
			else if (property.FieldType == typeof(System.Collections.Generic.List<System.String>)) {
				json += Add_StringList(property.Name, (List<string>)property.GetValue(obj), level, i == len, debug);
			}
			else if (property.FieldType == typeof(System.Collections.Generic.List<System.Boolean>)) {
				json += Add_BooleanList(property.Name, (List<bool>)property.GetValue(obj), level, i == len, debug);
			}
			// DICTIONARIES
			else if (property.FieldType == typeof(System.Collections.Generic.Dictionary<System.String, System.Int32>)) {
				json += Add_String_Int_Dictionary( property.Name, (Dictionary<string, int>)property.GetValue( obj ), level, i == len );
			}
			else if (property.FieldType == typeof(System.Collections.Generic.Dictionary<System.String, System.String>)) {
				json += Add_String_String_Dictionary(property.Name, (Dictionary<string, string>)property.GetValue(obj), level, i == len, debug);
			}
			else if (property.FieldType == typeof(System.Collections.Generic.Dictionary<System.String, System.Boolean>)) {
				json += Add_String_Boolean_Dictionary(property.Name, (Dictionary<string, bool>)property.GetValue(obj), level, i == len);
			}
			else if (property.FieldType == typeof(System.Collections.Generic.Dictionary<System.String, System.Collections.Generic.List<System.Int32>>)) {
				json += Add_String_IntList_Dictionary(property.Name, (Dictionary<string, List<int>>)property.GetValue(obj), level, i == len);
			}
			else if (property.FieldType == typeof(System.Collections.Generic.Dictionary<System.String, System.Collections.Generic.List<System.String>>)) {
				json += Add_String_StringList_Dictionary(property.Name, (Dictionary<string, List<string>>)property.GetValue(obj), level, i == len);
			}
			else if (property.FieldType == typeof(System.Collections.Generic.Dictionary<System.Int32, MapInfoItemData>)) {
				json += Add_Int_MapInfoItemData_Dictionary(property.Name, (Dictionary<int, MapInfoItemData>)property.GetValue(obj), level, i == len, debug);
			}
			else if (property.FieldType == typeof(System.Collections.Generic.Dictionary<string, MapObjectSpacialData>)) {
				json += Add_String_MapObjectSpacialData_Dictionary(property.Name, (Dictionary<string, MapObjectSpacialData>)property.GetValue(obj), level, i == len, debug);
			}
			//else if ( property.FieldType == typeof( System.Collections.Generic.Dictionary<System.String, SizeCategoryData> ) ) {
			//	json += Add_String_SizeCategoryData_Dictionary( property.Name, (Dictionary<string, SizeCategoryData>)property.GetValue( obj ), level, i == len );
			//}
			//else if ( property.FieldType == typeof( System.Collections.Generic.Dictionary<System.String, RangeData> ) ) {
			//	json += Add_String_RangeData_Dictionary( property.Name, (Dictionary<string, RangeData>)property.GetValue( obj ), level, i == len );
			//}
			//else if ( property.FieldType == typeof( System.Collections.Generic.Dictionary<System.String, DamageTypeData> ) ) {
			//	json += Add_String_DamageTypeData_Dictionary( property.Name, (Dictionary<string, DamageTypeData>)property.GetValue( obj ), level, i == len, debug );
			//}
			//else if ( property.FieldType == typeof( System.Collections.Generic.Dictionary<System.String, AttributeData> ) ) {
			//	json += Add_String_AttributeData_Dictionary( property.Name, (Dictionary<string, AttributeData>)property.GetValue( obj ), level, i == len, debug );
			//}
			else {
				Debug.Log(property.FieldType + " is not handled by JSON creator...");
			}
			i++;
		}
		if (json[json.Length - 2] == ',') {
			json = json.Substring(0, json.Length - 2) + "\n";
		}
		json += Ident(level - 1) + "}";
		if ( debug ) {
			Debug.Log("Encoded json: " + json);
		}
		return json;
	}

	private static string Add_Int(string name, int value, int level, bool last) {
		return Ident(level) + "\"" + name + "\": " + value + (last ? "" : ",") + "\n";
	}

	private static string Add_Float(string name, float value, int level, bool last) {
		return Ident(level) + "\"" + name + "\": " + value + (last ? "" : ",") + "\n";
	}

	private static string Add_String(string name, string value, int level, bool last) {
		return Ident(level) + "\"" + name + "\": \"" + WriteString(value) + "\"" + (last ? "" : ",") + "\n";
	}

	private static string Add_Boolean(string name, bool value, int level, bool last) {
		return Ident(level) + "\"" + name + "\": " + value.ToString().ToLower() + (last ? "" : ",") + "\n";
	}

	private static string Add_MapTreeNode(string name, MapTreeNode value, int level, bool last, bool debug = false) {
		if (debug) { Debug.Log("---> Add_MapTreeNode()"); }
		MapTreeNode mtn = value;
		return Ident(level) + "\"" + name + "\": " + (value == null ? "\"-\"" : mtn.uid) + (last ? "" : ",") + "\n";
	}

	private static string Add_IntArray(string name, int[] values, int level, bool last) {
		string res = "";
		int len = values.Length;
		res += Ident(level) + "\"" + name + "\": [\n";
		for (int i = 0; i < len; i++) {
			res += Ident(level + 1) + values[i] + (i == (len - 1) ? "\n" : ",\n");
		}
		res += Ident(level) + "]" + (last ? "" : ",") + "\n";
		return res;
	}

	private static string Add_StringArray( string name, string[] values, int level, bool last, bool debug = false ) {
		string res = "";
		int len = values.Length;
		res += Ident( level ) + "\"" + name + "\": [\n";
		for ( int i = 0; i < len; i++ ) {
			res += Ident(level + 1) + "\"" + WriteString(values[i]) + "\"" + (i == (len - 1) ? "\n" : ",\n");
		}
		res += Ident( level ) + "]" + ( last ? "" : "," ) + "\n";
		return res;
	}

	private static string Add_IntList( string name, List<int> values, int level, bool last ) {
		string res = "";
		int len = values.Count;
		res += Ident( level ) + "\"" + name + "\": [\n";
		for ( int i = 0; i < len; i++ ) {
			res += Ident( level + 1 ) + values[i] + ( i == ( len - 1 ) ? "\n" : ",\n" );
		}
		res += Ident( level ) + "]" + ( last ? "" : "," ) + "\n";
		return res;
	}

	private static string Add_StringList( string name, List<string> values, int level, bool last, bool debug = false ) {
		if ( debug ) { Debug.Log( "---> AddStringListProperty()" ); }
		string res = "";
		int len = values.Count;
		res += Ident( level ) + "\"" + name + "\": [\n";
		for ( int i = 0; i < values.Count; i++ ) {
			if ( debug ) { Debug.Log( values[i] ); }
			res += Ident( level + 1 ) + "\"" + WriteString( values[i] ) + "\"";
			if ( i == ( len - 1 ) ) {
				res += "\n";
			}
			else {
				res += ",\n";
			}
		}
		res += Ident( level ) + "]" + ( last ? "" : "," ) + "\n";
		return res;
	}

	private static string Add_BooleanList(string name, List<bool> values, int level, bool last, bool debug = false) {
		string res = "";
		int len = values.Count;
		res += Ident(level) + "\"" + name + "\": [\n";
		for ( int i = 0; i < len; i++ ) {
			res += Ident(level + 1) + values[i].ToString().ToLower() + (i == (len - 1) ? "\n" : ",\n");
		}
		res += Ident(level) + "]" + (last ? "" : ",") + "\n";
		return res;
	}

	private static string Add_MapTreeNode_List(string name, List<MapTreeNode> values, int level, bool last, bool debug = false) {
		if (debug) { Debug.Log("---> Add_MapTreeNode_List()"); }
		string res = "";
		int len = values.Count;
		res += Ident(level) + "\"" + name + "\": [\n";
		for (int i = 0; i < len; i++) {
			res += Ident(level + 1) + values[i].uid + (i == (len - 1) ? "\n" : ",\n");
		}
		res += Ident(level) + "]" + (last ? "" : ",") + "\n";
		return res;
	}

	private static string Add_String_Int_Dictionary( string name, Dictionary<string, int> values, int level, bool last ) {
		string res = "";
		List<string> keys = new List<string>( values.Keys );
		int len = keys.Count;
		res += Ident( level ) + "\"" + name + "\": {\n";
		for ( int i = 0; i < len; i++ ) {
			res += Ident( level + 1 ) + "\"" + keys[i] + "\": " + values[keys[i]].ToString() + ( i == ( len - 1 ) ? "" : "," ) + "\n";
		}
		res += Ident( level ) + "}" + ( last ? "" : "," ) + "\n";
		return res;
	}

	private static string Add_String_String_Dictionary( string name, Dictionary<string, string> values, int level, bool last, bool debug = false ) {
		string res = "";
		List<string> keys = new List<string>( values.Keys );
		int len = keys.Count;
		res += Ident( level ) + "\"" + name + "\": {\n";
		for ( int i = 0; i < len; i++ ) {
			res += Ident( level + 1 ) + "\"" + keys[i] + "\": " + "\"" + WriteString( values[keys[i]] ) + "\"" + ( i == ( len - 1 ) ? "" : "," ) + "\n";
		}
		res += Ident( level ) + "}" + ( last ? "" : "," ) + "\n";
		return res;
	}

	private static string Add_String_Boolean_Dictionary( string name, Dictionary<string, bool> values, int level, bool last ) {
		string res = "";
		List<string> keys = new List<string>( values.Keys );
		int len = keys.Count;
		res += Ident( level ) + "\"" + name + "\": {\n";
		for ( int i = 0; i < len; i++ ) {
			res += Ident( level + 1 ) + "\"" + keys[i] + "\": " + values[keys[i]].ToString().ToLower() + ( i == ( len - 1 ) ? "" : "," ) + "\n";
		}
		res += Ident( level ) + "}" + ( last ? "" : "," ) + "\n";
		return res;
	}

	private static string Add_String_IntList_Dictionary( string name, Dictionary<string, List<int>> values, int level, bool last ) {
		string res = "";
		List<string> keys = new List<string>( values.Keys );
		int len = keys.Count;
		res += Ident( level ) + "\"" + name + "\": {\n";
		for (int i = 0; i < len; i++) {
			res += Ident(level + 1) + "\"" + keys[i] + "\": [\n";
			List<int> list = values[keys[i]];
			int count = list.Count;
			for (int j = 0; j < count; j++) {
				res += Ident(level + 2) + list[j].ToString() + (j == (count - 1) ? "" : ",") + "\n";
			}
			res += Ident( level + 1 ) + "]" + ( i == ( len - 1 ) ? "" : "," ) + "\n";
		}
		res += Ident(level) + "}" + (last ? "" : ",") + "\n";
		return res;
	}

	private static string Add_String_StringList_Dictionary(string name, Dictionary<string, List<string>> values, int level, bool last) {
		string res = "";
		List<string> keys = new List<string>(values.Keys);
		int len = keys.Count;
		res += Ident(level) + "\"" + name + "\": {\n";
		for (int i = 0; i < len; i++) {
			res += Ident(level + 1) + "\"" + keys[i] + "\": [\n";
			List<string> list = values[keys[i]];
			int count = list.Count;
			for (int j = 0; j < count; j++) {
				res += Ident(level + 2) + "\"" + WriteString(list[j]) + "\"" + (j == (count - 1) ? "" : ",") + "\n";
			}
			res += Ident(level + 1) + "]" + (i == (len - 1) ? "" : ",") + "\n";
		}
		res += Ident(level) + "}" + (last ? "" : ",") + "\n";
		return res;
	}

	private static string Add_Int_MapInfoItemData_Dictionary(string name, Dictionary<int, MapInfoItemData> values, int level, bool last, bool debug = false) {
		if (debug) { Debug.Log("---> Add_Int_MapInfoItemData_Dictionary()"); }
		string res = "";
		List<int> keys = new List<int>(values.Keys);
		int len = keys.Count;
		if (debug) { Debug.Log("found " + len + " map info items..."); }
		res += Ident(level) + "\"" + name + "\": {\n";
		for (int i = 0; i < len; i++) {
			res += Ident(level + 1)  + "\"" + keys[i] + "\": ";
			MapInfoItemData miid = values[keys[i]];
			res += ToJson(miid, level + 2, debug) + (i == (len - 1) ? "" : ",") + "\n";
		}
		res += Ident(level) + "}" + (last ? "" : ",") + "\n";
		if (debug) { Debug.Log(res); }
		return res;
	}

	private static string Add_String_MapObjectSpacialData_Dictionary(string name, Dictionary<string, MapObjectSpacialData> values, int level, bool last, bool debug = false) {
		string res = "";
		List<string> keys = new List<string>(values.Keys);
		int len = keys.Count;
		if (debug) { Debug.Log("found " + len + " map spacial data items..."); }
		res += Ident(level) + "\"" + name + "\": {\n";
		for (int i = 0; i < len; i++) {
			res += Ident(level + 1) + "\"" + keys[i] + "\": ";
			MapObjectSpacialData mosd = values[keys[i]];
			res += ToJson(mosd, level + 2, debug) + (i == (len - 1) ? "" : ",") + "\n";
		}
		res += Ident(level) + "}" + (last ? "" : ",") + "\n";
		if (debug) { Debug.Log(res); }
		return res;
	}

	//private static string Add_String_SizeCategoryData_Dictionary( string name, Dictionary<string, SizeCategoryData> dict, int level, bool last ) {
	//	string res = "";
	//	res += Ident( level ) + "\"" + name + "\": {\n";
	//	List<string> keys = new List<string>( dict.Keys );
	//	int len = keys.Count;
	//	for ( int i = 0; i < len; i++ ) {
	//		res += Ident( level + 1 ) + "\"" + keys[i] + "\": " + ToJson( dict[keys[i]], level + 2 ) + ( i == ( len - 1 ) ? "" : "," ) + "\n";
	//	}
	//	res += Ident( level ) + "}" + ( last ? "" : "," ) + "\n";
	//	return res;
	//}

	//private static string Add_String_RangeData_Dictionary( string name, Dictionary<string, RangeData> dict, int level, bool last ) {
	//	string res = "";
	//	res += Ident( level ) + "\"" + name + "\": {\n";
	//	List<string> keys = new List<string>( dict.Keys );
	//	int len = keys.Count;
	//	for ( int i = 0; i < len; i++ ) {
	//		res += Ident( level + 1 ) + "\"" + keys[i] + "\": " + ToJson( dict[keys[i]], level + 2 ) + ( i == ( len - 1 ) ? "" : "," ) + "\n";
	//	}
	//	res += Ident( level ) + "}" + ( last ? "" : "," ) + "\n";
	//	return res;
	//} // AddStringRangeDataDictionaryProperty()

	//private static string Add_String_DamageTypeData_Dictionary( string name, Dictionary<string, DamageTypeData> dict, int level, bool last, bool debug = false ) {
	//	string res = "";
	//	res += Ident( level ) + "\"" + name + "\": {\n";
	//	List<string> keys = new List<string>( dict.Keys );
	//	int len = keys.Count;
	//	for ( int i = 0; i < len; i++ ) {
	//		res += Ident( level + 1 ) + "\"" + keys[i] + "\": " + ToJson( dict[keys[i]], level + 2, debug ) + ( i == ( len - 1 ) ? "" : "," ) + "\n";
	//	}
	//	res += Ident( level ) + "}" + ( last ? "" : "," ) + "\n";
	//	return res;
	//} // Add_String_DamageTypeData_Dictionary_Property()

	//private static string Add_String_AttributeData_Dictionary( string name, Dictionary<string, AttributeData> dict, int level, bool last, bool debug = false ) {
	//	string res = "";
	//	res += Ident( level ) + "\"" + name + "\": {\n";
	//	List<string> keys = new List<string>( dict.Keys );
	//	int len = keys.Count;
	//	for ( int i = 0; i < len; i++ ) {
	//		res += Ident( level + 1 ) + "\"" + keys[i] + "\": " + ToJson( dict[keys[i]], level + 2, debug ) + ( i == ( len - 1 ) ? "" : "," ) + "\n";
	//	}
	//	res += Ident( level ) + "}" + ( last ? "" : "," ) + "\n";
	//	return res;
	//} // Add_String_AttributeData_Dictionary()


	///////////////////
	///   DECODER   ///
	///////////////////
	public static object FromJson( object obj, string json, bool debug = false ) {
		if ( debug ) {
			Debug.Log( "Decoded (to be) json: " + json );
		}
		int firstBracket = json.IndexOf( '{' );
		int lastBracket = json.LastIndexOf( '}' );
		if ( ( firstBracket < 0 ) || ( lastBracket < 0 ) ) {
			Debug.Log( "The provided json is not valid: " + json );
			return obj;
		}
		string stream = json.Substring(firstBracket + 1, lastBracket - firstBracket - 1).Trim();
		//Debug.Log(stream);
		// Read the json object from start to finish and create a dictionary with corresponding keys and values.
		Dictionary<string, string> readProperties = GetKeysValuesDictionary(stream);
		// Get the object's properties, and then attach appropriate values based on the properties read from the json.
		string key = "", value = "";
		FieldInfo[] properties = obj.GetType().GetFields();
		foreach (FieldInfo property in properties) {
			key = property.Name;
			if (debug) { Debug.Log("--- property name: " + key + ", preperty type: " + property.FieldType.ToString()); }
			if (readProperties.ContainsKey(key)) { // check if the property exists in the read properties
				value = readProperties[key];
				// PRIMITIVES
				if (debug) { Debug.Log("--- value read: " + value); }
				// Try to parse the value based on its type and attach it to the object.
				if (property.FieldType == typeof(System.Int32)) {
					property.SetValue(obj, Parse_Int(value, debug));
				}
				else if (property.FieldType == typeof(System.Single)) {
					property.SetValue(obj, Parse_Single(value, debug));
				}
				else if (property.FieldType == typeof(System.String)) {
					property.SetValue(obj, Parse_String(value));
				}
				else if (property.FieldType == typeof(System.Boolean)) {
					property.SetValue(obj, Parse_Boolean(value));
				}
				// CUSTOM OBJECTS
				// ARRAYS
				else if (property.FieldType == typeof(System.Int32[])) {
					property.SetValue(obj, Parse_IntArray(value));
				}
				else if (property.FieldType == typeof(System.String[])) {
					property.SetValue(obj, Parse_StringArray(value, debug));
				}
				// LISTS
				else if (property.FieldType == typeof(System.Collections.Generic.List<System.Int32>)) {
					property.SetValue(obj, Parse_IntList(value));
				}
				else if (property.FieldType == typeof(System.Collections.Generic.List<System.String>)) {
					property.SetValue(obj, Parse_StringList(value, debug));
				}
				else if (property.FieldType == typeof(System.Collections.Generic.List<System.Boolean>)) {
					property.SetValue(obj, Parse_BooleanList(value, debug));
				}
				//else if (property.FieldType == typeof(System.Collections.Generic.List<MapTreeNode>)) {
				//}
				// DICTIONARIES
				else if (property.FieldType == typeof(System.Collections.Generic.Dictionary<System.String, System.Int32>)) {
					property.SetValue(obj, Parse_String_Int_Dictionary(value));
				}
				else if (property.FieldType == typeof(System.Collections.Generic.Dictionary<System.String, System.String>)) {
					property.SetValue(obj, Parse_String_String_Dictionary(value, debug));
				}
				else if (property.FieldType == typeof(System.Collections.Generic.Dictionary<System.String, System.Boolean>)) {
					property.SetValue(obj, Parse_String_Boolean_Dictionary(value, debug));
				}
				else if (property.FieldType == typeof(System.Collections.Generic.Dictionary<System.String, System.Collections.Generic.List<System.Int32>>)) {
					property.SetValue(obj, Parse_String_IntList_Dictionary(value));
				}
				else if (property.FieldType == typeof(System.Collections.Generic.Dictionary<System.String, System.Collections.Generic.List<System.String>>)) {
					property.SetValue(obj, Parse_String_StringList_Dictionary(value, debug));
				}
				else if (property.FieldType == typeof(System.Collections.Generic.Dictionary<System.Int32, MapInfoItemData>)) {
					property.SetValue(obj, Parse_Int_MapInfoData_Dictionary(value, debug));
				}
				else if (property.FieldType == typeof(System.Collections.Generic.Dictionary<string, MapObjectSpacialData>)) {
					property.SetValue(obj, Parse_String_MapObjectSpacialData_Dictionary(value, debug));
				}
				//else if (property.FieldType == typeof( System.Collections.Generic.Dictionary<System.String, SizeCategoryData> ) ) {
				//	property.SetValue( obj, Parse_String_SizeCategoryData_Dictionary( value ) );
				//}
				//else if (property.FieldType == typeof( System.Collections.Generic.Dictionary<System.String, RangeData> ) ) {
				//	property.SetValue( obj, Parse_String_RangeData_Dictionary( value ) );
				//}
				//else if (property.FieldType == typeof( System.Collections.Generic.Dictionary<System.String, DamageTypeData> ) ) {
				//	property.SetValue( obj, Parse_String_DamageTypeData_Dictionary( value, debug ) );
				//}
				//else if (property.FieldType == typeof( System.Collections.Generic.Dictionary<System.String, AttributeData> ) ) {
				//	property.SetValue( obj, Parse_String_AttributeData_Dictionary( value, debug ) );
				//}
				else {
					Debug.Log(property.FieldType + " is not handled by JSON parser...");
				}
			}
		}
		return obj;
	}

	private static int Parse_Int(string value, bool debug = false) {
		if (debug) { Debug.Log("---> Parse_Int(" + value + ")"); }
		int res = 0;
		int.TryParse(value, out res);
		if (debug) { Debug.Log("res: " + res); }
		return res;
	}

	private static float Parse_Single(string value, bool debug = false) {
		if (debug) { Debug.Log("---> Parse_Single(" + value + ")"); }
		if (value.Contains(".")) {
			float res = 0.0f;
			float.TryParse(value, NumberStyles.Any, CultureInfo.InvariantCulture, out res);
			if (debug) { Debug.Log("res: " + res); }
			return res;
		}
		else {
			return (float)Parse_Int(value, debug);
		}
	}

	private static string Parse_String( string value, bool debug = false ) {
		string res = "";
		int firstQuote = value.IndexOf( "\"" );
		int lastQuote = value.LastIndexOf( "\"" );
		if ((firstQuote >= 0) && (lastQuote >= 0) && (lastQuote > firstQuote)) {
			res = value.Substring( firstQuote + 1, lastQuote - firstQuote - 1 );
		}
		return ReadString( res );
	}

	private static bool Parse_Boolean( string value ) {
		//Debug.Log( value + " -> " + ( ( ( value == "true" ) || ( value == "True" ) ) ? true : false ).ToString() );
		return ( ( value == "true" ) || ( value == "True" ) ) ? true : false;
	}

	private static int[] Parse_IntArray(string value) {
		int indexStart = value.IndexOf('[');
		int indexEnd = value.LastIndexOf(']');
		int[] res = new int[] { };
		if ( ( indexStart >= 0 ) && ( indexEnd >= 0 ) && ( indexEnd > indexStart ) ) {
			string stream = value.Substring(indexStart + 1, indexEnd - indexStart - 1);
			string[] values = stream.Split(',');
			int len = values.Length;
			if ( len > 0 ) {
				res = new int[len];
				for ( int i = 0; i < len; i++ ) {
					int.TryParse(values[i].Trim(), out res[i]);
				}
			}
		}
		return res;
	}

	private static string[] Parse_StringArray( string value, bool debug = false ) {
		if (debug) { Debug.Log("---> ParseStringArray (" + value + ")"); }
		int indexStart = value.IndexOf('[');
		int indexEnd = value.LastIndexOf(']');
		string[] res = new string[] { };
		if ( ( indexStart >= 0 ) && ( indexEnd >= 0 ) && ( indexEnd > indexStart ) ) {
			string stream = value.Substring( indexStart + 1, indexEnd - indexStart - 1 ).Trim();
			if ( debug ) { Debug.Log(stream); }
			string[] values = GetStringArray(stream, debug);
			int len = values.Length;
			if ( len > 0 ) {
				res = new string[len];
				for ( int i = 0; i < len; i++ ) {
					res[i] = ReadString(values[i].Trim());
				}
			}
		}
		return res;
	}

	private static List<int> Parse_IntList( string value ) {
		int indexStart = value.IndexOf( '[' );
		int indexEnd = value.LastIndexOf( ']' );
		List<int> res = new List<int>();
		if ( ( indexStart >= 0 ) && ( indexEnd >= 0 ) && ( indexEnd > indexStart ) ) {
			string stream = value.Substring( indexStart + 1, indexEnd - indexStart - 1 );
			string[] values = stream.Split( ',' );
			int len = values.Length;
			if ( len > 0 ) {
				for ( int i = 0; i < len; i++ ) {
					int val = 0;
					int.TryParse( values[i].Trim(), out val );
					res.Add( val );
				}
			}
		}
		return res;
	}

	private static List<string> Parse_StringList( string value, bool debug = false ) {
		if ( debug ) { Debug.Log( "---> ParseStringList (" + value + ")" ); }
		int indexStart = value.IndexOf( '[' );
		int indexEnd = value.LastIndexOf( ']' );
		List<string> res = new List<string>();
		if ( ( indexStart >= 0 ) && ( indexEnd >= 0 ) && ( indexEnd > indexStart ) ) {
			string stream = value.Substring( indexStart + 1, indexEnd - indexStart - 1 );
			if ( debug ) { Debug.Log( "stream: " + stream ); }
			string[] values = GetStringArray( stream, debug );
			int len = values.Length;
			foreach ( string val in values ) {
				res.Add( ReadString( val ) );
			}
		}
		if ( debug ) { Debug.Log( "ParseStringList out: " + res.Aggregate( "", ( x, y ) => { return x + "-" + y; } ) ); }
		return res;
	}

	private static List<bool> Parse_BooleanList( string value, bool debug = false ) {
		int indexStart = value.IndexOf( '[' );
		int indexEnd = value.LastIndexOf( ']' );
		List<bool> res = new List<bool>();
		if ( ( indexStart >= 0 ) && ( indexEnd >= 0 ) && ( indexEnd > indexStart ) ) {
			string stream = value.Substring( indexStart + 1, indexEnd - indexStart - 1 );
			string[] values = stream.Split( ',' );
			int len = values.Length;
			if ( len > 0 ) {
				for ( int i = 0; i < len; i++ ) {
					res.Add( ( ( values[i] == "true" ) || ( values[i] == "True" ) ) ? true : false );
				}
			}
		}
		return res;
	}

	private static Dictionary<string, int> Parse_String_Int_Dictionary( string value ) {
		Dictionary<string, int> res = new Dictionary<string, int>();
		int indexStart = value.IndexOf( '{' );
		int indexEnd = value.LastIndexOf( '}' );
		//Debug.Log( indexStart.ToString() + "-" + indexEnd.ToString() );
		if ( ( indexStart >= 0 ) && ( indexEnd >= 0 ) && ( indexStart < indexEnd ) ) {
			string stream = value.Substring( indexStart + 1, indexEnd - indexStart - 1 ).Trim();
			if ( stream.Length > 0 ) {
				string[] keyValues = stream.Split( ',' );
				int len = keyValues.Length;
				foreach ( string kv in keyValues ) {
					string[] kvs = kv.Split( ':' );
					string key = kvs[0].Trim();
					int val = 0;
					int.TryParse( kvs[1].Trim(), out val );
					res.Add( key.Substring( 1, key.Length - 2 ), val );
				}
			}
		}
		return res;
	}

	private static Dictionary<string, string> Parse_String_String_Dictionary( string value, bool debug = false ) {
		if ( debug ) { Debug.Log( "---> Parse_String_String_Dictionary ( " + value + " )" ); }
		Dictionary<string, string> res = new Dictionary<string, string>();
		int indexStart = value.IndexOf( '{' );
		int indexEnd = value.LastIndexOf( '}' );
		if ( debug ) { Debug.Log( indexStart.ToString() + "-" + indexEnd.ToString() ); }
		if ( ( indexStart >= 0 ) && ( indexEnd >= 0 ) && ( indexStart < indexEnd ) ) {
			string stream = value.Substring( indexStart + 1, indexEnd - indexStart - 1 ).Trim();
			if ( debug ) { Debug.Log( "stream: " + stream ); }
			if ( stream.Length > 0 ) {
				Dictionary<string, string> keyValuePairs = GetKeysValuesDictionary( stream );
				foreach ( KeyValuePair<string, string> pair in keyValuePairs ) {
					if ( debug ) { Debug.Log( pair.Key + " <-> " + pair.Value ); }
					int firstQuote = pair.Value.IndexOf( "\"" );
					int lastQuote = pair.Value.LastIndexOf( "\"" );
					if ( ( firstQuote >= 0 ) && ( lastQuote >= 0 ) && ( lastQuote > firstQuote ) ) {
						res.Add( pair.Key, ReadString( pair.Value.Substring( firstQuote + 1, lastQuote - firstQuote - 1 ) ) );
					}
				}
			}
		}
		return res;
	}

	private static Dictionary<string, bool> Parse_String_Boolean_Dictionary(string value, bool debug = false) {
		Dictionary<string, bool> res = new Dictionary<string, bool>();
		int indexStart = value.IndexOf('{');
		int indexEnd = value.LastIndexOf('}');
		string stream = value.Substring(indexStart + 1, indexEnd - indexStart - 1).Trim();
		if (debug) { Debug.Log("stream: ->" + stream + "<-"); }
		if (stream.Length > 0) {
			string[] keyValues = stream.Split(',');
			int len = keyValues.Length;
			if (debug) { Debug.Log("keysAndValues: " + keyValues.Aggregate("", (x, y) => { return x + "-" + y; })); }
			foreach (string kv in keyValues) {
				string[] kvs = kv.Split(':');
				string key = kvs[0].Trim();
				bool val = ((kvs[1].Trim() == "true") || (kvs[1].Trim() == "True")) ? true : false;
				res.Add(key.Substring(1, key.Length - 2), val);
			}
		}
		return res;
	}

	private static Dictionary<string, List<int>> Parse_String_IntList_Dictionary(string value) {
		Dictionary<string, List<int>> res = new Dictionary<string, List<int>>();
		int indexStart = value.IndexOf('{');
		int indexEnd = value.LastIndexOf('}');
		if ((indexStart >= 0) && (indexEnd >= 0) && (indexStart < indexEnd)) {
			string stream = value.Substring(indexStart + 1, indexEnd - indexStart - 1).Trim();
			if (stream.Length > 0) {
				Dictionary<string, string> keyValuePairs = GetKeysValuesDictionary(stream);
				foreach (KeyValuePair<string, string> pair in keyValuePairs) {
					List<int> values = new List<int>();
					int open = pair.Value.IndexOf('[');
					int close = pair.Value.LastIndexOf(']');
					string[] valuesStr = pair.Value.Substring(open + 1, close - open - 1).Split(',');
					for (int i = 0; i < valuesStr.Length; i++) {
						int val = 0;
						int.TryParse(valuesStr[i].Trim(), out val);
						values.Add(val);
					}
					res.Add(pair.Key.Trim(), values);
				}
			}
		}
		return res;
	}

	private static Dictionary<string, List<string>> Parse_String_StringList_Dictionary(string value, bool debug = false) {
		if (debug) { Debug.Log("---> Parse_String_StringList_Dictionary( " + value + " )"); }
		Dictionary<string, List<string>> res = new Dictionary<string, List<string>>();
		int indexStart = value.IndexOf( '{' );
		int indexEnd = value.LastIndexOf( '}' );
		if ((indexStart >= 0) && (indexEnd >= 0) && (indexStart < indexEnd)) {
			string stream = value.Substring(indexStart + 1, indexEnd - indexStart - 1).Trim();
			if (debug) { Debug.Log("stream: " + stream); }
			if (stream.Length > 0) {
				Dictionary<string, string> keyValuePairs = GetKeysValuesDictionary(stream);
				foreach (KeyValuePair<string, string> pair in keyValuePairs) {
					if (debug) { Debug.Log("key: " + pair.Key + " <-> value: " + pair.Value); }
					int open = pair.Value.IndexOf('[');
					int close = pair.Value.LastIndexOf(']');
					string[] strvalues = GetStringArray(pair.Value, debug);
					List<string> values = new List<string>();
					foreach (string val in strvalues) {
						values.Add(ReadString(val));
					}
					res.Add(pair.Key.Trim(), values);
				}
			}
		}
		return res;
	}

	private static Dictionary<int, MapInfoItemData> Parse_Int_MapInfoData_Dictionary(string value, bool debug = false) {
		if (debug) { Debug.Log("---> Parse_Int_MapInfoData_Dictionary( " + value + " )"); }
		Dictionary<int, MapInfoItemData> res = new Dictionary<int, MapInfoItemData>();
		int indexStart = value.IndexOf('{');
		int indexEnd = value.LastIndexOf('}');
		if ((indexStart >= 0) && (indexEnd >= 0) && (indexStart < indexEnd)) {
			string stream = value.Substring(indexStart + 1, indexEnd - indexStart - 1).Trim();
			if (debug) { Debug.Log("stream: " + stream); }
			if (stream.Length > 0) {
				Dictionary<string, string> keyValuePairs = GetKeysValuesDictionary(stream);
				foreach (KeyValuePair<string, string> pair in keyValuePairs) {
					if (debug) { Debug.Log("key: " + pair.Key + " <-> value: " + pair.Value); }
					res.Add(Int32.Parse(pair.Key), (MapInfoItemData)JsonObject.FromJson(new MapInfoItemData(), pair.Value, debug));
				}
			}
		}
		return res;
	}

	private static Dictionary<string, MapObjectSpacialData> Parse_String_MapObjectSpacialData_Dictionary(string value, bool debug = false) {
		if (debug) { Debug.Log("---> Parse_String_MapObjectSpacialData_Dictionary( " + value + " )"); }
		Dictionary<string, MapObjectSpacialData> res = new Dictionary<string, MapObjectSpacialData>();
		int indexStart = value.IndexOf('{');
		int indexEnd = value.LastIndexOf('}');
		if ((indexStart >= 0) && (indexEnd >= 0) && (indexStart < indexEnd)) {
			string stream = value.Substring(indexStart + 1, indexEnd - indexStart - 1).Trim();
			if (debug) { Debug.Log("stream: " + stream); }
			if (stream.Length > 0) {
				Dictionary<string, string> keyValuePairs = GetKeysValuesDictionary(stream);
				foreach (KeyValuePair<string, string> pair in keyValuePairs) {
					if (debug) { Debug.Log("key: " + pair.Key + " <-> value: " + pair.Value); }
					MapObjectSpacialData mosd = (MapObjectSpacialData)JsonObject.FromJson(new MapObjectSpacialData(), pair.Value, false);
					if(debug) { Debug.Log(mosd.ToString()); }
					res.Add(pair.Key, mosd);
				}
			}
		}
		return res;
	}

	//private static Dictionary<string, SizeCategoryData> Parse_String_SizeCategoryData_Dictionary( string value ) {
	//	Dictionary<string, SizeCategoryData> res = new Dictionary<string, SizeCategoryData>();
	//	int indexStart = value.IndexOf( '{' );
	//	int indexEnd = value.LastIndexOf( '}' );
	//	string stream = value.Substring( indexStart + 1, indexEnd - indexStart - 1 ).Trim();
	//	if ( stream.Length > 0 ) {
	//		Dictionary<string, string> keyValuesDictionary = GetKeysValuesDictionary( stream );
	//		foreach ( KeyValuePair<string, string> kv in keyValuesDictionary ) {
	//			res.Add( kv.Key, (SizeCategoryData)FromJson( new SizeCategoryData(), kv.Value ) );
	//		}
	//	}
	//	return res;
	//}

	//private static Dictionary<string, RangeData> Parse_String_RangeData_Dictionary( string value ) {
	//	Dictionary<string, RangeData> res = new Dictionary<string, RangeData>();
	//	int indexStart = value.IndexOf( '{' );
	//	int indexEnd = value.LastIndexOf( '}' );
	//	string stream = value.Substring( indexStart + 1, indexEnd - indexStart - 1 ).Trim();
	//	if ( stream.Length > 0 ) {
	//		Dictionary<string, string> keyValuesDictionary = GetKeysValuesDictionary( stream );
	//		foreach ( KeyValuePair<string, string> kv in keyValuesDictionary ) {
	//			res.Add( kv.Key, (RangeData)FromJson( new RangeData(), kv.Value ) );
	//		}
	//	}
	//	return res;
	//}

	//private static Dictionary<string, DamageTypeData> Parse_String_DamageTypeData_Dictionary( string value, bool debug = false ) {
	//	Dictionary<string, DamageTypeData> res = new Dictionary<string, DamageTypeData>();
	//	int indexStart = value.IndexOf( '{' );
	//	int indexEnd = value.LastIndexOf( '}' );
	//	string stream = value.Substring( indexStart + 1, indexEnd - indexStart - 1 ).Trim();
	//	if ( stream.Length > 0 ) {
	//		Dictionary<string, string> keyValuesDictionary = GetKeysValuesDictionary( stream );
	//		foreach ( KeyValuePair<string, string> kv in keyValuesDictionary ) {
	//			res.Add( kv.Key, (DamageTypeData)FromJson( new DamageTypeData(), kv.Value, debug ) );
	//		}
	//	}
	//	return res;
	//}

	//private static Dictionary<string, AttributeData> Parse_String_AttributeData_Dictionary( string value, bool debug = false ) {
	//	Dictionary<string, AttributeData> res = new Dictionary<string, AttributeData>();
	//	int indexStart = value.IndexOf( '{' );
	//	int indexEnd = value.LastIndexOf( '}' );
	//	string stream = value.Substring( indexStart + 1, indexEnd - indexStart - 1 ).Trim();
	//	if ( stream.Length > 0 ) {
	//		Dictionary<string, string> keyValuesDictionary = GetKeysValuesDictionary( stream );
	//		foreach ( KeyValuePair<string, string> kv in keyValuesDictionary ) {
	//			res.Add( kv.Key, (AttributeData)FromJson( new AttributeData(), kv.Value, debug ) );
	//		}
	//	}
	//	return res;
	//}


	////////////////////////////
	///   HELPER FUNCTIONS   ///
	////////////////////////////
	private static string Ident(int lvl) {
		if (lvl > 0) {
			return String.Concat(Enumerable.Repeat(" ", 4 * lvl));
		}
		else {
			return "";
		}
	}

	private static Dictionary<string, string> GetKeysValuesDictionary(string dict) {
		/// <summary>
		/// This function gets a json stringified dictionary and breaks it up into a <string, string> dictionary of the original keys and values.
		/// Returned keys are strings ready for use.
		/// Returned values are strings that contain everything (even escape characters, like \", and thus have to be cleaned before they will be parsed.
		/// </summary>
		Dictionary<string, string> res = new Dictionary<string, string>();
		int openQuotes = 0, openBrackets = 0, openList = 0, len = dict.Length;
		string key = "", value = "";
		bool keyFound = false, valueFound = false, readingKey = false, readingValue = false;
		// Read the json object from start to finish and create a dictionary with corresponding keys and values.
		for (int i = 0; i < len; i++) {
			//Debug.Log( "---> " + stream[i] + " at " + i.ToString() );
			switch (dict[i]) {
				case '\"':
					if (!keyFound && (openBrackets == 0)) {
						if ((openBrackets == 0) && (openQuotes == 0)) {
							//Debug.Log( "-> case \" (start)" );
							readingKey = true;
							//openQuotes++;
						}
						else {
							//Debug.Log( "-> case \" (end)" );
							readingKey = false;
							//openQuotes--;
						}
					}
					if ( openQuotes == 0 ) {
						openQuotes++;
					}
					else {
						openQuotes--;
					}
					break;
				case '{':
					//Debug.Log( "-> case {" );
					openBrackets++;
					break;
				case '}':
					//Debug.Log( "-> case }" );
					openBrackets--;
					break;
				case '[':
					//Debug.Log( "-> case [" );
					openList++;
					break;
				case ']':
					//Debug.Log( "-> case ]" );
					openList--;
					break;
				case ':':
					if (openBrackets == 0) {
						//Debug.Log( "-> case :" );
						keyFound = true;
						readingValue = true;
					}
					break;
				case ',':
					if ((openBrackets == 0) && (openList == 0) && (openQuotes == 0)) {
						//Debug.Log( "-> case ," );
						valueFound = true;
						readingValue = false;
					}
					break;
				default:
					break;
			}
			if (readingKey) {
				//Debug.Log( "-> reading key..." );
				key += dict[i];
			}
			else if (readingValue) {
				//Debug.Log( "-> reading value..." );
				value += dict[i];
			}
			if (keyFound && (valueFound || (i == (len - 1)))) {
				//Debug.Log( "-> FOUND KEY & VALUE" );
				//Debug.Log( "---------------   key: " + key.Substring(1).Trim() );
				//Debug.Log( "---------------   value: " + value.Substring(1).Trim() );
				res.Add(key.Substring(1).Trim(), value.Substring(1).Trim());
				key = "";
				value = "";
				keyFound = false;
				valueFound = false;
			}
		}
		return res;
	}

	private static string[] GetStringArray( string list, bool debug = false ) {
		if (debug) { Debug.Log("---> GetStringArray( " + list + " )"); }
		string[] res = new string[] { };
		List<string> items = new List<string>();
		int openQuotes = 0, len = 0;
		string item = "";
		foreach (char c in list.Trim()) {
			if (c == '\"') {
				if (openQuotes == 0) {
					openQuotes++;
				}
				else {
					openQuotes--;
				}
			}
			else if ( c == ',' ) {
				if ( openQuotes == 0 ) {
					items.Add(item);
					item = "";
				}
				else {
					item += c;
				}
			}
			else if (openQuotes == 1) {
				item += c;
			}
		}
		if (item.Length > 0) {
			items.Add(item);
		}
		len = items.Count;
		if (len > 0) {
			res = new string[len];
			for (int i = 0; i < len; i++) {
				res[i] = items[i];
			}
		}
		if (debug) { Debug.Log("GetStringArray out: " + items.Aggregate("", (x, y) => { return x + "-" + y; })); }
		return res;
	}

	private static string ReadString( string str ) {
		string res = str.Replace("\\n", "\n");
		// TODO: Add all ecape characters here...
		return res;
	}

	private static string WriteString(string str) {
		string res = str.Replace("\n", "\\n");
		return res;
	}


}
