package com.emids.da.utilities;

import java.sql.Date;

public class DateConverter {

  /**
   * Converts java.util.Date to java.sql.Date
   *
   * @param utilDate utilDate
   * @return java.sql.Date
   */
  public static Date toSQL(java.util.Date utilDate) {
    java.sql.Date sqlDate;
    sqlDate = new Date(utilDate.getTime());

    return sqlDate;
  }
}
