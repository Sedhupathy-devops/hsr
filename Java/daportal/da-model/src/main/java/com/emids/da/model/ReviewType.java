package com.emids.da.model;

import lombok.Builder;
import lombok.Data;
import lombok.EqualsAndHashCode;

import javax.persistence.Entity;

@Data
@EqualsAndHashCode(callSuper = false)
@Builder
@Entity
public class ReviewType extends BaseEntity {

  private static final long serialVersionUID = -7432042107923056287L;

  private String reviewName;
  private String reviewTypeCode;
}
