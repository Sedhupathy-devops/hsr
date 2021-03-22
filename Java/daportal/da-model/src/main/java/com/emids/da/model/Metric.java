package com.emids.da.model;

import lombok.Builder;
import lombok.Data;
import lombok.EqualsAndHashCode;

import javax.persistence.Entity;

@Data
@EqualsAndHashCode(callSuper = false)
@Builder
@Entity
public class Metric extends BaseEntity {

  private static final long serialVersionUID = -183359228810012234L;

  private int month;
  private int projectId;
  private String sprintDetails;
  private String measures;
  private boolean exceptionFlag;
}
