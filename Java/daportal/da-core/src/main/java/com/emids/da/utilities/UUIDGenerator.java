package com.emids.da.utilities;

import com.fasterxml.uuid.Generators;

import java.util.UUID;

public final class UUIDGenerator {

  /**
   * Return a time base UUID
   *
   * @return
   */
  public static UUID newUUID() {
    return Generators.timeBasedGenerator().generate();
  }
}
