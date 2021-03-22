package com.emids.da.commons.enumerations;

public enum AppEnvironment {
  LOCAL("local"),
  QA("qa"),
  UAT("uat"),
  PRODUCTION("prod");

  final String environment;

  AppEnvironment(final String environment) {
    this.environment = environment;
  }

  public String getEnvironment() {
    return environment;
  }
}
