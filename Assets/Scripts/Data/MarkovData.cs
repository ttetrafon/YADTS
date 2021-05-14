using System.Collections;
using System.Collections.Generic;

public class MarkovData {
  public string generatorName;
  public string generatorUid;
  public List<string> namesSeed;
  public Dictionary<string, Dictionary<string, float>> markovOrder1;
  public Dictionary<string, Dictionary<string, float>> markovOrder2;
  public Dictionary<string, Dictionary<string, float>> markovOrder3;


  public MarkovData() {
    this.generatorUid = Helper.GenerateUid();
    this.generatorName = "";
    this.namesSeed = new List<string>();
    this.markovOrder1 = new Dictionary<string, Dictionary<string, float>>();
    this.markovOrder2 = new Dictionary<string, Dictionary<string, float>>();
    this.markovOrder3 = new Dictionary<string, Dictionary<string, float>>();
  }
}
