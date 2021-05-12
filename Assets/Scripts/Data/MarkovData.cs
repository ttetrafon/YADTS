using System.Collections;
using System.Collections.Generic;

public class MarkovData {
  public List<string> namesSeed = new List<string>();
  public Dictionary<string, Dictionary<string, float>> markovOrder1 = new Dictionary<string, Dictionary<string, float>>();
  public Dictionary<string, Dictionary<string, float>> markovOrder2 = new Dictionary<string, Dictionary<string, float>>();
  public Dictionary<string, Dictionary<string, float>> markovOrder3 = new Dictionary<string, Dictionary<string, float>>();


  public MarkovData() {
    this.namesSeed = new List<string>();
    this.markovOrder1 = new Dictionary<string, Dictionary<string, float>>();
    this.markovOrder2 = new Dictionary<string, Dictionary<string, float>>();
    this.markovOrder3 = new Dictionary<string, Dictionary<string, float>>();
  }
}
