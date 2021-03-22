package com.emids.da.commons.enumerations;

public enum RatingThreshold {
  MAX_THRESHOLD(60),
  MIN_THRESHOLD(0);

  final int thresholdValue;

  RatingThreshold(final int thresholdValue) {
    this.thresholdValue = thresholdValue;
  }

  public int getThresholdValue() {
    return thresholdValue;
  }
}
