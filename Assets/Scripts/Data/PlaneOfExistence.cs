using System.Collections;
using System.Collections.Generic;

public class PlaneOfExistence {
  public string uid;
  public string name;

  public PlaneOfExistence() : this(Helper.GenerateUid()) {}
  public PlaneOfExistence(string uid) {
    this.uid = uid;
    this.name = "";
  }

}
