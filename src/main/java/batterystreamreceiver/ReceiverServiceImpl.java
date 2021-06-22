package batterystreamreceiver;

import java.util.ArrayList;
import java.util.List;

public class ReceiverServiceImpl {
	public static void main(String args[]) {

		List<Float> socValues = new ArrayList<Float>();
		List<Float> temperatureValues = new ArrayList<Float>();

		BatteryProperties battery = new BatteryProperties();
		CheckBatteryProperties propertyEvaluator = new CheckBatteryProperties();

		if (args.length > 0) {
			for (String dataInput : args) {
				if (dataInput.equalsIgnoreCase("stateofcharge,temperature")) {
					continue;
				}
				String batteryProperties[] = dataInput.split(",");
				if (batteryProperties.length == 2) {
					socValues.add(Float.valueOf(batteryProperties[0]));
					temperatureValues.add(Float.valueOf(batteryProperties[1]));
				} else {
					System.out.println("Data streamed not a valid data- " + dataInput);
				}
			}

			checkBatteryTemperatureProperties(temperatureValues, battery, propertyEvaluator);
			checkBatterySocProperties(socValues, battery, propertyEvaluator);
			PrintProperty print = new ReportBatteryPropeties();
			print.printReport(battery);

		}

	}

	public static void checkBatterySocProperties(List<Float> socList, BatteryProperties battery,
			CheckBatteryProperties propertyEvaluator) {
		battery.setMaxSoc(propertyEvaluator.getMaxSocValue(socList));
		battery.setMinSoc(propertyEvaluator.getMinSocValue(socList));
		battery.setAverageSoc(propertyEvaluator.getAverageInSocListValues(socList));
	}

	public static void checkBatteryTemperatureProperties(List<Float> chargeRateList, BatteryProperties battery,
			CheckBatteryProperties propertyEvaluator) {
		battery.setAverageChargeRate(propertyEvaluator.getAverageInTemperatureList(chargeRateList));
		battery.setMinChargeRate(propertyEvaluator.getMinTemperatureValue(chargeRateList));
		battery.setMaxChargeRate(propertyEvaluator.getMaxTemperatureValue(chargeRateList));
	}

}
