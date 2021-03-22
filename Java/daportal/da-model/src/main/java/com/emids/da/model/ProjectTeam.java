package com.emids.da.model;

import lombok.Builder;
import lombok.Data;
import lombok.EqualsAndHashCode;

import javax.persistence.Entity;

@Data
@EqualsAndHashCode(callSuper = false)
@Builder
@Entity
public class ProjectTeam extends BaseEntity {

  private static final long serialVersionUID = -6453966134129643879L;

  private String teamName;
  private String teamComposition; // JSON
  private int projectId;
  private String methodology;
  private int sprintCycle;
}
