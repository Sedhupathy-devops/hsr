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
public class ReviewerAvailability extends BaseEntity {

  private static final long serialVersionUID = 6641344134220468976L;

  private int reviewerId;
  private String month;
  private int year;
  private Date leaveStartDate;
  private Date leaveEndDate;
  private String remarks;
}
