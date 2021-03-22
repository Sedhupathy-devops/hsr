package com.emids.da.model;

import lombok.Builder;
import lombok.Data;
import lombok.EqualsAndHashCode;

import javax.persistence.Entity;

@Data
@EqualsAndHashCode(callSuper = false)
@Builder
@Entity
public class DAActivity extends BaseEntity {

  private static final long serialVersionUID = -6634287323660910096L;

  private String activityName;
  private String task;
}
