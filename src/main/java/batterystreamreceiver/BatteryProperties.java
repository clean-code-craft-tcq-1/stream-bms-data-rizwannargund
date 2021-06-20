package batterystreamreceiver;

public class BatteryProperties {
	private Float maxTemperature;
	private Float minTemperature;
	private Float maxSoc;
	private Float minSoc;
	private Double averageTemperature;
	private Double averageSoc;

	public Float getMaxChargeRate() {
		return maxTemperature;
	}

	public void setMaxChargeRate(Float maxChargeRate) {
		this.maxTemperature = maxChargeRate;
	}

	public Float getMaxSoc() {
		return maxSoc;
	}

	public void setMaxSoc(Float maxSoc) {
		this.maxSoc = maxSoc;
	}

	public Double getAverageChargeRate() {
		return averageTemperature;
	}

	public void setAverageChargeRate(Double averageChargeRate) {
		this.averageTemperature = averageChargeRate;
	}

	public Double getAverageSoc() {
		return averageSoc;
	}

	public void setAverageSoc(Double averageSoc) {
		this.averageSoc = averageSoc;
	}

	public Float getMinChargeRate() {
		return minTemperature;
	}

	public void setMinChargeRate(Float minChargeRate) {
		this.minTemperature = minChargeRate;
	}

	public Float getMinSoc() {
		return minSoc;
	}

	public void setMinSoc(Float minSoc) {
		this.minSoc = minSoc;
	}

}