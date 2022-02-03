import { BatteryLevel, BatteryType } from '../enums'

export type BatteryInformation = {
    BatteryType: BatteryType;
    BatteryLevel: BatteryLevel;
}