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
public class Reviewer extends BaseEntity {

  private static final long serialVersionUID = -7285755838248211955L;

  private String firstName;
  private String middleName;
  private String lastName;
  private String emailId;
  private String practiceArea; // JSON
  private String role;
  private boolean active;
  private Date startDate;
  private Date endDate;
  private int reviewTypeId;
}
