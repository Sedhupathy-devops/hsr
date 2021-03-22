package com.emids.da.model;

import java.util.HashMap;
import java.util.Map;
import lombok.Data;
import lombok.EqualsAndHashCode;

@Data
@EqualsAndHashCode(callSuper = false)
public class AdditionalProperties {

  private static final long serialVersionUID = -3401240905554433475L;

  private Map<String, String> additionalProperties;

  AdditionalProperties() {
    additionalProperties = new HashMap<>();
  }
}
