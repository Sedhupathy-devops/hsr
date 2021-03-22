package com.emids.da.utilities;

import com.emids.da.PortalException;

import java.nio.charset.StandardCharsets;
import java.security.MessageDigest;
import java.security.NoSuchAlgorithmException;
import java.util.logging.Level;
import java.util.logging.Logger;

import static com.emids.da.commons.constants.ApplicationConstants.*;

public class PasswordUtil {

  private final char[] hexArray = HEX_ARRAY.toCharArray();

  private String bytesToHex(byte[] bytes) {
    char[] hexChars = new char[bytes.length * 2];
    int v;
    for (int j = 0; j < bytes.length; j++) {
      v = bytes[j] & 0xFF;
      hexChars[j * 2] = hexArray[v >>> 4];
      hexChars[j * 2 + 1] = hexArray[v & 0x0F];
    }
    return new String(hexChars);
  }

  /**
   * A password hashing method.
   *
   * @param passwordToHash password to hash
   * @return hashed password!
   */
  public String hashPassword(final String passwordToHash) {
    try {
      MessageDigest messageDigest = MessageDigest.getInstance(ALGORITHM);
      messageDigest.update(SALT_VALUE.getBytes(StandardCharsets.UTF_8)); // <-- Prepend SALT.
      messageDigest.update(passwordToHash.getBytes(StandardCharsets.UTF_8));

      byte[] out = messageDigest.digest();
      return bytesToHex(out); // <-- Return the Hex Hash.
    } catch (NoSuchAlgorithmException e) {
      Logger.getAnonymousLogger()
        .log(Level.WARNING, "There was a problem hashing the password", new PortalException(e));
    }
    return "";
  }
}
