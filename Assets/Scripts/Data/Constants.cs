using System.Collections.Generic;

public class Constants {
	public static string gridTypeNone = "none";
	public static string gridTypeHex = "hex";
	public static string gridTypeSquare = "square";

	public static int gameObjectActiveNoOverride = 0;
	public static int gameObjectActiveOverrideTrue = 1;
	public static int gameObjectActiveOverrideFalse = 2;
	public static List<int> circleDivisors = new List<int>() { 1, 2, 3, 4, 5, 6, 8, 9, 10, 12, 15, 18, 20, 24, 30, 36, 40, 45, 60, 72, 90, 120, 180, 360 };
}
