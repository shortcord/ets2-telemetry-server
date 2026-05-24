using System.Runtime.CompilerServices;

namespace Funbit.Ets.Telemetry.Data
{
    public sealed class Ets2Truck
    {
        readonly StrongBox<Ets2TelemetryStructure> _rawData;

        public Ets2Truck(StrongBox<Ets2TelemetryStructure> rawData)
        {
            _rawData = rawData;
        }

        public string Id => _rawData.Value.truckMakeId.BytesToString();
        public string Make => _rawData.Value.truckMake.BytesToString();
        public string Model => _rawData.Value.truckModel.BytesToString();

        /// <summary>
        /// Truck speed in km/h.
        /// </summary>
        public float Speed => _rawData.Value.speed * 3.6f;

        /// <summary>
        /// Cruise control speed in km/h.
        /// </summary>
        public float CruiseControlSpeed => _rawData.Value.cruiseControlSpeed * 3.6f;

        public bool CruiseControlOn => _rawData.Value.cruiseControl != 0;
        public float Odometer => _rawData.Value.truckOdometer;
        public int Gear => _rawData.Value.gear;
        public int DisplayedGear => _rawData.Value.displayedGear;
        public int ForwardGears => _rawData.Value.gearsForward;
        public int ReverseGears => _rawData.Value.gearsReverse;
        public string ShifterType => _rawData.Value.shifterType.BytesToString();
        public float EngineRpm => _rawData.Value.engineRpm;
        public float EngineRpmMax => _rawData.Value.engineRpmMax;
        public float Fuel => _rawData.Value.fuel;
        public float FuelCapacity => _rawData.Value.fuelCapacity;
        public float FuelAverageConsumption => _rawData.Value.fuelAvgConsumption;
        public float FuelWarningFactor => _rawData.Value.fuelWarningFactor;
        public bool FuelWarningOn => _rawData.Value.fuelWarning != 0;
        public float WearEngine => _rawData.Value.wearEngine;
        public float WearTransmission => _rawData.Value.wearTransmission;
        public float WearCabin => _rawData.Value.wearCabin;
        public float WearChassis => _rawData.Value.wearChassis;
        public float WearWheels => _rawData.Value.wearWheels;
        public float UserSteer => _rawData.Value.userSteer;
        public float UserThrottle => _rawData.Value.userThrottle;
        public float UserBrake => _rawData.Value.userBrake;
        public float UserClutch => _rawData.Value.userClutch;
        public float GameSteer => _rawData.Value.gameSteer;
        public float GameThrottle => _rawData.Value.gameThrottle;
        public float GameBrake => _rawData.Value.gameBrake;
        public float GameClutch => _rawData.Value.gameClutch;
        public int ShifterSlot => _rawData.Value.shifterSlot;

        public bool EngineOn => _rawData.Value.engineEnabled != 0;
        public bool ElectricOn => _rawData.Value.electricEnabled != 0;
        public bool WipersOn => _rawData.Value.wipers != 0;
        public int RetarderBrake => _rawData.Value.retarderBrake;
        public int RetarderStepCount => (int)_rawData.Value.retarderStepCount;
        public bool ParkBrakeOn => _rawData.Value.parkBrake != 0;
        public bool MotorBrakeOn => _rawData.Value.motorBrake != 0;
        public float BrakeTemperature => _rawData.Value.brakeTemperature;
        public float Adblue => _rawData.Value.adblue;
        public float AdblueCapacity => _rawData.Value.adblueCapacity;
        public float AdblueAverageConsumption => _rawData.Value.adblueConsumption;
        public bool AdblueWarningOn => _rawData.Value.adblueWarning != 0;
        public float AirPressure => _rawData.Value.airPressure;
        public bool AirPressureWarningOn => _rawData.Value.airPressureWarning != 0;
        public float AirPressureWarningValue => _rawData.Value.airPressureWarningValue;
        public bool AirPressureEmergencyOn => _rawData.Value.airPressureEmergency != 0;
        public float AirPressureEmergencyValue => _rawData.Value.airPressureEmergencyValue;
        public float OilTemperature => _rawData.Value.oilTemperature;
        public float OilPressure => _rawData.Value.oilPressure;
        public bool OilPressureWarningOn => _rawData.Value.oilPressureWarning != 0;
        public float OilPressureWarningValue => _rawData.Value.oilPressureWarningValue;
        public float WaterTemperature => _rawData.Value.waterTemperature;
        public bool WaterTemperatureWarningOn => _rawData.Value.waterTemperatureWarning != 0;
        public float WaterTemperatureWarningValue => _rawData.Value.waterTemperatureWarningValue;
        public float BatteryVoltage => _rawData.Value.batteryVoltage;
        public bool BatteryVoltageWarningOn => _rawData.Value.batteryVoltageWarning != 0;
        public float BatteryVoltageWarningValue => _rawData.Value.batteryVoltageWarningValue;
        public float LightsDashboardValue => _rawData.Value.lightsDashboard;
        public bool LightsDashboardOn => _rawData.Value.lightsDashboard > 0;
        public bool BlinkerLeftActive => _rawData.Value.blinkerLeftActive != 0;
        public bool BlinkerRightActive => _rawData.Value.blinkerRightActive != 0;
        public bool BlinkerLeftOn => _rawData.Value.blinkerLeftOn != 0;
        public bool BlinkerRightOn => _rawData.Value.blinkerRightOn != 0;
        public bool LightsParkingOn => _rawData.Value.lightsParking != 0;
        public bool LightsBeamLowOn => _rawData.Value.lightsBeamLow != 0;
        public bool LightsBeamHighOn => _rawData.Value.lightsBeamHigh != 0;
        public bool LightsAuxFrontOn => _rawData.Value.lightsAuxFront != 0;
        public bool LightsAuxRoofOn => _rawData.Value.lightsAuxRoof != 0;
        public bool LightsBeaconOn => _rawData.Value.lightsBeacon != 0;
        public bool LightsBrakeOn => _rawData.Value.lightsBrake != 0;
        public bool LightsReverseOn => _rawData.Value.lightsReverse != 0;

        public Ets2Placement Placement => new Ets2Placement(
            _rawData.Value.coordinateX,
            _rawData.Value.coordinateY,
            _rawData.Value.coordinateZ,
            _rawData.Value.rotationX,
            _rawData.Value.rotationY,
            _rawData.Value.rotationZ);

        public Ets2Vector Acceleration => new Ets2Vector(
            _rawData.Value.accelerationX,
            _rawData.Value.accelerationY,
            _rawData.Value.accelerationZ);

        public Ets2Vector Head => new Ets2Vector(
            _rawData.Value.headPositionX,
            _rawData.Value.headPositionY,
            _rawData.Value.headPositionZ);

        public Ets2Vector Cabin => new Ets2Vector(
            _rawData.Value.cabinPositionX,
            _rawData.Value.cabinPositionY,
            _rawData.Value.cabinPositionZ);

        public Ets2Vector Hook => new Ets2Vector(
            _rawData.Value.hookPositionX,
            _rawData.Value.hookPositionY,
            _rawData.Value.hookPositionZ);
    }
}
