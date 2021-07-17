using System.Collections;
using System.Collections.Generic;

public class PlaneOfExistenceData {
  public string uid;
  public string name;

  public PlaneOfExistenceData() : this(Helper.GenerateUid()) {}
  public PlaneOfExistenceData(string uid) {
    this.uid = uid;
    this.name = "";
  }

}
