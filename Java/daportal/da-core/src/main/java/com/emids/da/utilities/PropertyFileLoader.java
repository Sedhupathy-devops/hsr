package com.emids.da.utilities;

import com.emids.da.commons.enumerations.AppEnvironment;

import java.io.IOException;
import java.util.Objects;
import java.util.Properties;
import java.util.logging.Level;
import java.util.logging.Logger;

public final class PropertyFileLoader {
  /**
   * Singleton instance.
   */
  private static PropertyFileLoader fileLoaderInstance;

  /**
   * properties object that stores all the properties.
   */
  private final Properties props = new Properties();

  /**
   * A singleton class and hence a private constructor.
   */
  private PropertyFileLoader() {
  }

  /**
   * Return only one instance of the PropertyFileLoader class.
   *
   * @return PropertyFileLoader
   */
  public static PropertyFileLoader getInstance() {
    if (fileLoaderInstance == null) {

      fileLoaderInstance = new PropertyFileLoader();
    }
    return fileLoaderInstance;
  }

  /**
   * Method to read the property from the file.
   *
   * @param propertyName String
   * @return String
   */
  public String getProperty(final String propertyName) {
    return props.getProperty(propertyName);
  }

  /**
   * Loads the properties file from disk.
   */
  public void loadPropertiesFile() {
    try {
      /*
       * Ensure APP_ENVIRONEMENT is set in the server where the portal is installed.
       * Applicable APP_ENVIRONMENT values
       * 1. local
       * 2. qa
       * 3. uat
       * 4. prod
       */
      String environment = AppEnvironment.valueOf(System.getenv("APP_ENVIRONMENT")).toString();

      props.load(Objects.requireNonNull(
          this.getClass().getClassLoader().getResourceAsStream("database." + environment + ".properties")));
    } catch (IOException ioe) {
      Logger.getLogger(PropertyFileLoader.class.getName()).log(Level.SEVERE, null, ioe);
    }
  }
}
