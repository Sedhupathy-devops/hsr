package com.emids.da.model;

import lombok.Builder;
import lombok.Data;
import lombok.EqualsAndHashCode;

import javax.persistence.Entity;
import java.util.Date;

@Data
@EqualsAndHashCode(callSuper = false)
@Builder
@Entity
public class Project extends BaseEntity {

  private static final long serialVersionUID = 3024734526501202981L;

  private String projectName;
  private String projectCode;
  private Date startDate;
  private Date endDate;
  private int accountId;
  private String projectType;
  private String technologyStack; // JSON
  private String reviewFrequency;
  private int totalDataPoints;
  private int baselineDataPoints;
  private String review_types; // JSON
  private String location;
}
