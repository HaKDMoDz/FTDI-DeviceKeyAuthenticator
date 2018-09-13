# FTDI-DeviceKeyAuthenticator
FTDI232 Device information Gathered
* Device Serial Number
* Device Location
* Chip ID
Compares Official Device Chip Identification which is inbuilt into every Ftdi Serial Device
with Assigned authenticated device chip id based on my device's id. Used as a key for programming serial devices
such as the Esp8266 12E device.
If not the authenticated device id key then a message dialog will appear else if it is the correct id an authenticated
message will appear thereby allowing code flashing to project devices.

Official FTDI Device ChipID Key Detection 0x7F9CCFDD Device Key For Programming Esp8266 12E Project is the required device id.
