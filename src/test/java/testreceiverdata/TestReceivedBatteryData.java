package testreceiverdata;

import static org.junit.Assert.assertEquals;

import java.util.ArrayList;
import java.util.List;

import org.junit.Before;
import org.junit.Test;

import batterystreamreceiver.CheckBatteryProperties;

public class TestReceivedBatteryData {
	CheckBatteryProperties checkvalues;
	List<Float> socValues;
	List<Float> emptySocList;
	List<Float> nullSocList;

	List<Float> temperatureVaues;
	List<Float> emptyTemperatureList;
	List<Float> nullTemperatureList;

	@Before
	public void setup() {
		checkvalues = new CheckBatteryProperties();

		socValues = new ArrayList<Float>();
		socValues.add(78.6f);
		socValues.add(52.8f);
		socValues.add(24.7f);
		socValues.add(74.35f);
		socValues.add(76.9f);

		emptySocList = new ArrayList<Float>();
		nullSocList = null;

		temperatureVaues = new ArrayList<Float>();
		temperatureVaues.add(12.77f);
		temperatureVaues.add(57.25f);
		temperatureVaues.add(65.61f);
		temperatureVaues.add(2.4f);
		temperatureVaues.add(72.28f);

		emptyTemperatureList = new ArrayList<Float>();
		nullTemperatureList = null;
	}

	@Test
	public void givenSocValuesEmpty_whenEmptyList_thenReturnsZero() {
		Float maxSocValue = checkvalues.getMaxSocValue(emptySocList);
		assertEquals(Float.valueOf(0), maxSocValue);
	}

	@Test
	public void givenSocValues_whenEmptyList_thenReturnsZero() {
		Float minSocValue = checkvalues.getMinSocValue(emptySocList);
		assertEquals(Float.valueOf(0), minSocValue);
	}

	@Test
	public void givenSocValuesEmpty_checkAvgOfSoc_thenReturnZero() {
		Double averageSocValue = checkvalues.getAverageInSocListValues(emptySocList);
		assertEquals(Double.valueOf(0), averageSocValue);
	}

	@Test
	public void givenSocValues_checkMaxOfSoc_EqualstogivenMaxValue() {
		Float maxSocValue = checkvalues.getMaxSocValue(socValues);
		assertEquals(Float.valueOf(78.6f), maxSocValue);
	}

	@Test
	public void givenSocValues_whencheckMinOfSoc_EqualstogivenMinValue() {
		Float minSocValue = checkvalues.getMinSocValue(socValues);
		assertEquals(Float.valueOf(24.7f), minSocValue);
	}

	@Test
	public void givenSocValues_whencheckAvgOfSoc_equalsAverageProvided() {
		Double averageSoc = checkvalues.getAverageInSocListValues(socValues);
		assertEquals(Math.round(61), Math.round(averageSoc));
	}

	@Test
	public void givenTemperatureValuestisEmpty_thenReturnZero() {
		Float maxTemp = checkvalues.getMaxTemperatureValue(emptyTemperatureList);
		assertEquals(Float.valueOf(0f), maxTemp);
	}

	@Test
	public void givenTemperatureValuesEmpty_thenReturnZero() {
		Float minTemp = checkvalues.getMinTemperatureValue(emptyTemperatureList);
		assertEquals(Float.valueOf(0f), minTemp);
	}

	@Test
	public void givenTemperatureValuesisEmpty_checkAvgOfChargeRate_thenReturnZero() {
		Double averageTemperature = checkvalues.getAverageInTemperatureList(emptyTemperatureList);
		assertEquals(Double.valueOf(0), averageTemperature);
	}

	@Test
	public void givenTemperatureValues_checkMaxOfTemp_thenReturnMax() {
		Float maxTemperature = checkvalues.getMaxTemperatureValue(temperatureVaues);
		assertEquals(Float.valueOf(72.28f), maxTemperature);
	}

	@Test
	public void givenTemperatureValues_CheckMinOfTemp_thenReturnMin() {
		Float minTemperature = checkvalues.getMinTemperatureValue(temperatureVaues);
		assertEquals(Float.valueOf(2.4f), minTemperature);
	}

	@Test
	public void givenTemperatureValuesAveragewhenEquals() {
		Double averageTemperature = checkvalues.getAverageInTemperatureList(temperatureVaues);
		assertEquals(Math.round(42), Math.round(averageTemperature));
	}

}
