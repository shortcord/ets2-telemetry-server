# Changelog

All notable changes to this project will be documented in this file.

The format is based on [Keep a Changelog](https://keepachangelog.com/en/1.0.0/),
and this project adheres to [Semantic Versioning](https://semver.org/spec/v2.0.0.html).

---

## [3.2.5] - 2024

### Changed
- Improved job information reset code (plugin DLL update).

## [3.2.4] - 2024

### Added
- Support for SVG, GIF, TTF and WOFF content types.

## [3.2.3] - 2024

### Added
- Support for up to 9 levels of sub directories for skins to use (previous version allowed only 5).

### Changed
- Minor code refactoring.

## [3.2.2] - 2024

### Fixed
- Occasional bug in latest job information reset code (new job info might have been reset).

## [3.2.1] - 2024

### Added
- Support for sending UserId/Password for telemetry broadcaster to allow user identification.

### Changed
- Updated telemetry plugin DLL and fixed job information reset when job is done (trailer detached).

### Fixed
- Typo in property name: adblueAverageConsumption (was adblueAverageConsumpton).

## [3.2.0] - 2024

### Added
- Support for American Truck Simulator.
- Two new skins: MAN TGX (MPH) and Peterbilt 579 by NightstalkerPL, Lisek Chytrusek (by WEBX.PL).
- Application menu to ease uninstallation and extending for future updates.
- New GameName property to the telemetry (proposed by mkoch227).
- All project files updated for Visual Studio 2015 and C# 6.0.

### Fixed
- CPU overhead issue for some users (when CPU goes above 1%).

## [3.0.7] - 2024

### Fixed
- 'Dynamic' skin size display issue.

## [3.0.6] - 2024

### Added
- New 'Dynamic' skin size type, cursor fixes and other refactorings (thanks to denilsonsa & Phil0499!).

### Fixed
- Minor bug in the telemetry plugin with wrong hshifter.selector usage.

## [3.0.5] - 2024

### Changed
- Removed small visual padding around skins. Now skins take full canvas space (thanks to James).

### Fixed
- Rounding problem with speed limit value, sometimes it was displayed as 79 instead of 80 (thanks to R0adrunner).

## [3.0.4] - 2024

### Added
- Restored truck.engineOn property (separated from truck.electricOn).

## [3.0.3] - 2024

### Removed
- truck.engineOn property which was a duplicate for truck.electricOn property causing it not to work properly inside the telemetry plugin (thanks to ivanrichwalski).

## [3.0.2] - 2024

### Changed
- Property name format inside date-min/max HTML attributes; object separation character changed from '-' to '.' (example: `date-max="truck.fuelCapacity"` instead of `date-max="truck-fuelCapacity"`).

### Fixed
- Bug with parsing date-min/max HTML attributes.

## [3.0.1] - 2024

### Added
- New skin "rd-info" created by van_argiano.

### Fixed
- iOS Safari window reload bug (window gets reloaded several times in a row).

## [3.0.0] - 2024

### Added
- New telemetry JSON structure with properties organized in several categories: game, truck, trailer, job and navigation.
- Support for new telemetry properties: game.nextRestStopTime, game.timeScale, truck.forwardGears, truck.reverseGears, navigation.estimatedTime, navigation.estimatedDistance, navigation.speedLimit.
- [Complete telemetry property reference](Telemetry.md).
- [Forked ETS2 telemetry plugin](https://github.com/Funbit/ets2-sdk-plugin) to make it a custom part of the server.

### Changed
- Telemetry JSON object structure by introducing complex nested types. **Breaking change**: custom skins will not work without updates. Use the [Telemetry-Dashboard-3.0.0-Skin-Upgrader](http://funbit.info/ets2/Telemetry-Dashboard-3.0.0-Skin-Upgrader.zip) tool to automatically upgrade your skin files.
- Refer to the [updated skin tutorial](https://raw.githubusercontent.com/Funbit/ets2-telemetry-server/master/Dashboard%20Skin%20Tutorial.pdf) for more information.

### Removed
- hasJob property. Use `trailer.attached` property instead (or add custom `data.hasJob = data.trailer.attached;` to your dashboard.js).

### Fixed
- Aux light indicators (roof and front indicators didn't work).
- Various bug fixes and improvements.

## [2.2.6] - 2024

### Changed
- hasJob property now equals to the trailerAttached value.

### Fixed
- trailerAttached property so it is properly changed when trailer is attached/detached.
- Odometer for default MPH skin (was showing kilometers) (thanks to kevindwood).

## [2.2.5] - 2024

### Added
- New MPH version of the default skin.

### Fixed
- Truck speed rounding to avoid jumps between 0 and 1 km/h.
- Minor bug with cruise control speed displayed as NaN sometimes (default skin).

## [2.2.4] - 2024

### Fixed
- Speedometer for Scania and Volvo skins (made the needle movement smoother).
- Floating point rendering (truck speed sometimes might have been displayed as XX.YYYY) (big thanks to Jorji_costava and sketch).

## [2.2.3] - 2024

### Added
- Skin ability to control user clicks (back to menu link moved to dashboard.js) (greetings to mkoch227).

### Changed
- Speed rounding algorithm to match game's speed (greetings to maysaraahmad).

### Fixed
- Speedometer for all built-in skins (DAF, MAN, Mercedes, Volvo).
- Implemented automatic window reloading on resize (for PC) (greetings to denilsonsa).
- Minor comment and typo fixes.

## [2.2.2] - 2024

### Fixed
- Bug in Android APK (no IP address prompt).
- Scania skin (invalid speed limit).

## [2.2.1] - 2024

### Added
- Some utility functions to dashboard.js (see Skin Tutorial for more info).
- New server status: "Connected to Ets2TestTelemetry.json".

### Changed
- Completely revamped dashboard core, including rendering and connection layers. The mobile dashboard now reflects game changes almost instantly (within 5-10ms)!
- Removed refreshRate option (now it is adjusted automatically).

### Fixed
- fuelWarning telemetry property (updated telemetry plugin DLL).
- NaN trailer mass when dashboard is disconnected (default skin only).

## [2.2.0] - 2024

### Added
- Dashboard Skin Tutorial!
- Ability to skip certain setup steps to support 3rd-party firewalls.
- Ability to manually select ETS2 game path using standard UI when it is not detected automatically.
- Wear indicators to the default skin.
- Additional status message to check if server is connected to the telemetry plugin.
- Five new photo realistic skins made by Klauzzy (DAF-XF, MAN-TGX, Mercedes-Atego, Scania, Volvo-FH).
- Simple template skin.

### Changed
- Telemetry plugin DLL name from ets2-telemetry.dll to ets2-telemetry-server.dll (previous version is not compatible anymore).
- Significantly improved skin loading speed.

### Fixed
- Support for Cruise Control indicator and added Cruise Control Speed.
- Deadline time bug.
- Made speed value always positive (even when reversing).
- Various refactoring and improvements.

## [2.1.0] - 2024

### Added
- Moved to WebSockets for low-latency data updates.

### Changed
- Optimized UI animation (now it is SUPER SMOOTH, especially in Desktop and Mobile Safari browsers).

### Fixed
- Minor fixes.

## [2.0.0] - 2024

### Added
- Full support for custom skins.
- Automated server installer.
- Telemetry broadcasting to external URLs (see Ets2Telemetry.exe.config).

### Changed
- Completely rewritten client side application in Typescript.
- Updated default dashboard skin.

### Fixed
- Administrator rights are now required only for installation. Server starts under user privileges.

## [1.0.4] - 2024

### Added
- Server IP to the server window.

### Changed
- Minor logging improvements.

### Fixed
- IE behavior with ajax requests (should fix Windows Phone issues).

## [1.0.3] - 2024

### Added
- Some scripts to simplify the installation.

### Changed
- Completely decoupled gauge design and gauge update engine (coded in Typescript).
- Improved connection stability.

### Fixed
- Bug with invalid day of the week.

## [1.0.2] - 2024

### Added
- Logging.
- Support for binding on a particular network interface.
- Cordova mobile application (compiled Android APK is included in the bundle).

### Changed
- Refactored gauge screen fitting algorithm; the app should work in any modern browser now.
- Made HTML5 application URL shorter.

### Fixed
- Various fixes and improvements.

## [1.0.1] - 2024

### Added
- Application icon added to the HTML app.

### Changed
- Made application run under Administrator by default (thanks to thorerik).

### Fixed
- Bug with multiple network interfaces (thanks to thorerik).
- Minor refactoring and bug fixes.