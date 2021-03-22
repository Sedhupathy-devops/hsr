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
public class MonthlyPlan extends BaseEntity {

  private static final long serialVersionUID = 6745662672725045336L;

  private int projectId;
  private int reviewTypeId;
  private String reviewMonth;
  private String sprintDetails;
  private Date previousReviewDate;
  private int previousReviewerId;
  private Date reviewDate;
  private Date reviewTime;
  private String reviewLocation;
  private int reviewDuration;
  private String reviewDetails;
  private String rescheduleDetails;
  private String wsrDetails;
  private String requiredAttendees;
  private String optionalAttendees;
}
