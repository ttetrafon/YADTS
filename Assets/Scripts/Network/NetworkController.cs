using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Net.WebSockets;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NetworkController : MonoBehaviour {
	// serverStarted & connectedToServer are used to extend all other operations that should work over the network (like moving a game object, changing game system rules/values, etc)
	public static bool serverStarted = false;
	public static bool connectedToServer = false;
	private bool isTheHost = true; // Which set of controls is visible: create or join server.
	private TcpListener server;
	private string IP = "127.0.0.1";
	private int port = 2222;
	private List<TcpClient> clients = new List<TcpClient>();

	public InputField usernameInput;
	public Text ipDisplay;
	public InputField portInput;
	public Button startServerButton;
	public Button connectToServerButton;
	public Toggle isTheHostToggle;

	private void Start() {
		usernameInput.text = GameController.userData.userName;
		usernameInput.onEndEdit.AddListener(delegate {
			if (usernameInput.text != GameController.userData.userName) {
				GameController.userData.userName = usernameInput.text;
			}
			// TODO: Notify all connected.
		});
		portInput.text = port.ToString();
		portInput.onEndEdit.AddListener(delegate {
			int value = int.Parse(portInput.text);
			if ((value >= 2000) && (value < 10000)) {
				port = value;
			}
			else {
				portInput.text = port.ToString();
			}
			Debug.Log("port is now: " + port.ToString());
		});
		isTheHostToggle.onValueChanged.AddListener(delegate {
			if (serverStarted || connectedToServer) { // If already connected/hosting, do not swap the controls!
				return;
			}
			isTheHost = isTheHostToggle.isOn;
			DisplayControls();
		});
		startServerButton.onClick.AddListener(delegate {
			if (serverStarted) {
				StopServer();
			}
			else {
				StartServer();
			}
		});

		IP = GetExternalIp();
		ipDisplay.text = IP;
		//Debug.Log("current IP: " + IP);
	}

	private void Update() {
	}

	private void StartServer() {
		Debug.Log("---> StartServer()");
		try {
			server = new TcpListener(IPAddress.Parse(IP), port);
			server.Start();
			Debug.Log("... server started");
			serverStarted = true;

			//TcpClient newClient = server.AcceptTcpClient();
			//Debug.Log("... client connected");
		}
		catch (Exception e) {
			Debug.LogError("Server falied to start...");
			Debug.Log(e.StackTrace);
		}
	}

	private void StopServer() {
		server.Stop();
		serverStarted = false;
	}

	private string GetExternalIp() {
		return new WebClient().DownloadString("https://icanhazip.com").Trim();
		// https://ipinfo.io/ip/
		// https://api.ipify.org/
		// https://icanhazip.com/
		// https://checkip.amazonaws.com/
		// https://wtfismyip.com/text
	}

	private string GetLocalIp() {
		return Dns.GetHostEntry(Dns.GetHostName()).AddressList[0].ToString().Trim();
	}

	private void DisplayControls() {
		ipDisplay.gameObject.SetActive(isTheHost);
		startServerButton.gameObject.SetActive(isTheHost);
		connectToServerButton.gameObject.SetActive(!isTheHost);
	}

}
