package com.emids.da.model;

import lombok.Builder;
import lombok.Data;
import lombok.EqualsAndHashCode;

import javax.persistence.Entity;

@Data
@EqualsAndHashCode(callSuper = false)
@Builder
@Entity
public class KpiTracker extends BaseEntity {

  private static final long serialVersionUID = 5515514256685690569L;

  private String measure;
  private String definition;
  private String formula;
}
