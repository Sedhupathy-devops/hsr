package com.emids.da.commons.enumerations;

public enum Ratings {
  GREEN("GREEN"),
  AMBER("AMBER"),
  RED("RED"),
  AMBERGREEN("AMBER-GREEN"),
  AMBERRED("AMBER-RED");

  final String ratingCode;

  Ratings(final String ratingCode) {
    this.ratingCode = ratingCode;
  }

  public String getRatingCode() {
    return ratingCode;
  }
}
