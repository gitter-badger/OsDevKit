# Serial Protocol
The goal of the serial protocol is to allow the following interactions between the IDE and the OS:
* Break points
* Bebug console
* Dumps
  * registors dump
  * call stack
  * etc
  
# Design Goal
To make a fully expandable data pipeline.

# Packets
All packets have the following:
* ID (Byte)
* Data (Depends on packet)

#### List Of all packets

###### Debug Console Write
| Field      | Description              |
|------------|--------------------------|
| ID         | 0                        |
| DataLength | The Length of the String |
| Data       | Char[]                   |

###### Debug Console Read
Packet order:

OS -> IDE (send with state of 0) Ask for read line (wait for response).

IDE -> OS (send with state of 1) Sends string, OS continues.


| Field      | Description              |
|------------|--------------------------|
| ID         | 0                        |
| State      |                          |
| DataLength | The Length of the String |
| Data       | Char[]                   |

###### Registors Dump

| Field | Description          |
|-------|----------------------|
| ID    | 0                    |
| Eax   | 4 bytes (32 bit int) |
| Ebx   | 4 bytes (32 bit int) |
| Ecx   | 4 bytes (32 bit int) |
| Edx   | 4 bytes (32 bit int) |
| Esi   | 4 bytes (32 bit int) |
| Esp   | 4 bytes (32 bit int) |
| Ebp   | 4 bytes (32 bit int) |
