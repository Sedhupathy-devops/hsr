package com.emids.da.model;

import lombok.Builder;
import lombok.Data;
import lombok.EqualsAndHashCode;

import javax.persistence.Entity;

@Data
@EqualsAndHashCode(callSuper = false)
@Builder
@Entity
public class MeetingRoom extends BaseEntity {

  private static final long serialVersionUID = 2130557828988828591L;

  private String roomName;
  private String location;
  private String floor;
  private boolean excludeRoom;
}
