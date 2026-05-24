# This is a personal fork of FunBit's work
A lot of work is still needed, but atleast it works on linux :)

## ETS2 Telemetry Web Server 3.2.5 + Mobile Dashboard

This is a free Telemetry Web Server for [Euro Truck Simulator 2](http://www.eurotrucksimulator2.com/) and [American Truck Simulator](http://www.americantrucksimulator.com/) written in C# based on WebSockets and REST API.

The client side consists of a skinnable HTML5 mobile dashboard application that works in any modern desktop or mobile browser.

## Main Features

- Free and open source
- Automated installation
- REST API for telemetry data
- HTML5 dashboard application for live telemetry data streaming based on WebSockets 
- Powerful support for custom dashboard skins (skin tutorial included)
- Telemetry data broadcasting to a given URL via HTTP protocol

### Telemetry REST API
  
Endpoint: `http://localhost:25555/api/ets2/telemetry`

Returns structured JSON object with the latest telemetry data read from the game: 

```json
{    
	"game": {
		"connected": true,
		"paused": false,
		"gameName": "ETS2",
		"time": "0001-01-08T21:09:00Z",
		"timeScale": 19.0,
		"nextRestStopTime": "0001-01-01T10:11:00Z",
		"version": "1.10",
		"telemetryPluginVersion": "7"
	},
	"truck":{
		"id": "man",
		"make": "MAN",
		"model": "TGX",
		"speed": 53.82604,
		... 
}
```

The state is updated upon every API call. You may use this REST API for your own Applications. 

**The complete telemetry property reference is available [here](./docs/Telemetry.md).**

Please note that GET responses may be cached by your HTTP client. To avoid caching you may use some random query string parameter or POST method which returns exactly the same result.

### HTML5 Mobile Dashboard Application
Endpoint: `http://localhost:25555/`

This HTML5 dashboard application is designed for mobile and desktop browsers.

You should be able to use the dashboard just by navigating to the URL on either your phone, desktop, or another computer connected to the same network. 

Here is a screenshot of how your mobile dashboard will look like in a browser:

![](https://raw.githubusercontent.com/Funbit/ets2-telemetry-server/master/source/Funbit.Ets.Telemetry.Mobile/skins/default/dashboard.jpg)

As you can see dashboard design is completely customizable. With some basic knowledge of the HTML and CSS you can create your own skins.

See Dashboard skin tutorial below for more information. 

## Setup

### Supported OSes

Native plugin:
- Windows 10+ (32-bit and 64-bit) (though if you are running 10+ on 32-bit you should not.)
- Linux (Tested on Arch Linux 6.18.9-arch1-2)

### Supported games

- Euro Truck Simulator 2 version 1.15+ (Steam and Standalone)
- American Truck Simulator (Steam and Standalone)

### Tested browsers

- Literally any made within the last year

### Installation
TODO


### Skin Installation
TODO: explain this better, should be broken out into a wiki or `docs/` page.

If you downloaded some third-party skin (which is folder, containing dashboard.html, css, js and image files, but **no EXE files**!) you may install it just by **copying to server/Html/skins** directory. It should appear in the skin menu as soon as you refresh your browser.

### Upgrade

If you already have a previous version installed, it is recommended to leave it as is and **unpack the new version into a separate directory**. This way you will never lose your configuration files, logs, etc. 

However, please keep in mind that if you plan to return back to previous version you have to uninstall the latest one first!

### Uninstallation
TODO


## Usage
TODO

## FAQ

> I ran the server and opened HTML5 App URL on a device but browser says "Page not found". What should I do?

First of all, make sure that your device is using Wi-Fi connection instead of mobile internet (3G, 4G, etc.). Then, make sure that you selected correct "Network interface" on the main server screen. You must select the interface that is directly connected to your Wi-Fi network, *usually* it is named as "Wi-Fi", "Ethernet" or "LAN". Also, make sure that "AP Isolation" is disabled on your Wi-Fi router ([more info](http://www.howtogeek.com/179089/lock-down-your-wi-fi-network-with-your-routers-wireless-isolation-option/)). If you still can't connect - try to temporarily disable firewalls (especially from 3rd-parties) or anti-viruses and check again. If problem persists then you should contact to your Administrator... 

> I installed provided Android application, but it always shows "Could not connect to the server" or "Disconnected" status. How do I fix that?

Please check if you can connect to the dashboard from a browser first (read the answer above). If you are able to connect via browser then there is something wrong with the application (or Android environment). You may try to restart it or reinstall.

> I started the game but dashboard is displaying "Connected, waiting for the drive..." message. What is wrong?

Please make sure that the server window is showing "Connected to the simulator" status message. If it is showing "Simulator is running" instead - then there is a problem with the telemetry plugin installation (ets2-telemetry-server.dll). If it is showing "Simulator is not running" but simulator is actually running then you have an incompatible ETS2 version.

> The dashboard UI animation (meters) sometimes stutters. Is my device not good enough? Is it possible to fix that?

The HTML5 dashboard is optimized for modern browsers and fast network connections (LAN, local Wi-Fi), so you may experience problems on old devices or devices having old web browsers. 

Some performance examples:

The dashboard will work smoothly on Samgung Galaxy Tab S (4.4.2), but not on Galaxy Note 1 or Kindle Fire HD due to slow GPU or turned off GPU graphics acceleration. To achieve the best performance on Androids you may try to use a standalone Chrome browser instead of an app (but you will need to turn off device sleep mode when you use the dashboard). 

The dashboard will work very smoothly on iOS 8.X devices (iPhone 6 or new iPads). But it will not properly work on iOS 6.X (iPhone 3GS, old iPods). If you are experiencing slow performance even on new devices you may try to close all opened apps (especially Safari) and try again, that helps a lot.

The dashboard will perfectly work on any PC or laptop inside latest Firefox, Chrome or IE11.  

Also, do not forget to turn off background downloads, especially Torrent clients, because they may dramatically slow your connection between devices!

> Is it safe to use the server? Can it crash my game? What about influence on the game performance, say FPS, processor load?

The server is written very carefully. It will not crash your game, because the telemetry plugin was created by the official developers. It also does not eat CPU (the load is less than 1%) and has small memory footprint (around 20MB). So you won't notice any difference in FPS. 

If you don't trust the compiled exe/dll files you are always welcome to check them for viruses by more than 50 different anti-virus programs on [VirusTotal](https://www.virustotal.com/) site.

> Can I use mobile dashboard on Android 2.x devices?

No. There is a chance that it will work, but it won't be supported.

> Is it possible to include sleep indicator, remaining distance, ETA, current speed limit (or whatever else)?

Starting from version 3.0.0 this is possible, but I haven't yet had time to update the default skins to display it. But I will ;)


## [Changelog](./CHANGELOG.md)

## External links

Forums

- [Discussion on the official SCS forum](http://forum.scssoft.com/viewtopic.php?f=41&t=171000)

Video

- [Dashboard overview from SimplySimulators](https://www.youtube.com/watch?v=mM13wfTYfM8)
- [Dashboard usage with OBS from A JonC](https://www.youtube.com/watch?v=yLFu4DPixCM)
- [Dashboard overview from MrSoundwaves Cubes](https://www.youtube.com/watch?v=2OCs9RwA0AI)
- [Dashboard usage from z5teve](https://www.youtube.com/watch?v=gdwpTwhzZIg)
- [Dashboard overview from Driver Geo (Romanian)](https://www.youtube.com/watch?v=zcrmyD5wq10)
- [Dashboard overview from MaRKiToX12 (Spanish)](https://www.youtube.com/watch?v=J_SpwY8RIX4)
- [Dashboard overview from Branislav Rác (Slovak)](https://www.youtube.com/watch?v=LpKyuNWxJTU)
- [Dashboard overview from 1Tera Games (Portuguese)](https://www.youtube.com/watch?v=hfUMWmuLToQ)
- [Обзор от Саши Плотникова (на русском)](https://www.youtube.com/watch?v=mmNm27eTTBs)
  
## License

[GNU General Public License v3 (GPL-3)](https://tldrlegal.com/license/gnu-general-public-license-v3-%28gpl-3%29).