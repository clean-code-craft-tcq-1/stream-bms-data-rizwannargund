package batterystreamreceiver;

import java.util.Collections;
import java.util.List;

public class CheckBatteryProperties {

	private boolean findvalidValues(List<Float> values) {
		if (values.isEmpty() || null == values) {
			return true;
		}
		return false;
	}

	public Float getMaxSocValue(List<Float> socList) {
		if (findvalidValues(socList)) {
			return 0.0f;
		}
		return Collections.max(socList);
	}

	public Float getMinSocValue(List<Float> socList) {
		if (findvalidValues(socList)) {
			return 0.0f;
		}
		return Collections.min(socList);
	}

	public Float getMaxTemperatureValue(List<Float> chargeRateList) {
		if (findvalidValues(chargeRateList)) {
			return 0.0f;
		}
		return Collections.max(chargeRateList);
	}

	public Float getMinTemperatureValue(List<Float> chargeRateList) {
		if (findvalidValues(chargeRateList)) {
			return 0.0f;
		}
		return Collections.min(chargeRateList);
	}

	private boolean checkIfListIsValidForAveraging(List<Float> values) {
		if (findvalidValues(values) || values.size() < 5) {
			return true;
		}
		return false;
	}

	public Double getAverageInTemperatureList(List<Float> chargeRateList) {
		if (checkIfListIsValidForAveraging(chargeRateList)) {
			return (double) 0.0f;
		}
		List<Float> chargeRateSubList = separateLastFiveValues(chargeRateList);
		double sum = 0;
		for (Float arg : chargeRateSubList) {
			sum += arg;
		}
		double average = sum / 5;
		return average;
	}

	public Double getAverageInSocListValues(List<Float> socList) {
		if (checkIfListIsValidForAveraging(socList)) {
			return (double) 0.0f;
		}

		List<Float> socAvgList = separateLastFiveValues(socList);
		double sum = 0;
		for (Float arg : socAvgList) {
			sum += arg;
		}
		double average = sum / 5;
		return average;
	}

	private static List<Float> separateLastFiveValues(List<Float> valueList) {

		if (valueList.size() >= 5)
			return valueList.subList(valueList.size() - 5, valueList.size());
		return valueList;
	}

}
