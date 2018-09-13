# ®FTDI-DeviceKeyAuthenticator ©2018
FTDI232 Device information Gathered
* Device Serial Number
* Device Location
* Chip ID
Program Compares Official Device Chip Identification which is inbuilt into every Ftdi Serial Device
with Assigned authenticated device chip id based on my project device's id. Used as a key in my Wireless Light Controller project
If not the authenticated device id key then a message dialog will appear else if it is the correct id an authenticated
message will appear, allowing code flashing to the project device (Esp8266 12E NodeMCU - LUA Firmware)
Official FTDI Device ChipID Key Detection 0x7F9CCFDD Device Key For Programming Esp8266 12E Project is the required device id.
Developed in C-Sharp based on https://www.ftdichip.com/Support/SoftwareExamples/FTDIChip-ID/NET/CSharp/CSChipID.zip Original Project files.
Requirements:
  FTChipIDNet.dll
  FTChipID.dll
  .NET Components 2.0
Designed for Microsoft Windows Operating Systems
Compiled & Built on Windows 8.1 Pro x64 as Windows .Net Form Application 2.0
Developed in Visual Studio 2015
Licensed To HaKDModz™ Development modifications made by ®2018 HaKDMoDz™ 14/9/2018
