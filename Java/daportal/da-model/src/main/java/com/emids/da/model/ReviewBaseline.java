package com.emids.da.model;

import lombok.Builder;
import lombok.Data;
import lombok.EqualsAndHashCode;

import javax.persistence.Column;
import javax.persistence.Entity;

@Data
@EqualsAndHashCode(callSuper = false)
@Builder
@Entity
public class ReviewBaseline extends BaseEntity {

  @Column
  private String accountName;

  @Column
  private String projectName;

  @Column
  private float emScore;

  @Column
  private float qaScore;

  @Column
  private float tqScore;

  @Column
  private float baScore;

  @Column
  private float biScore;

  @Column
  private float reviewScore;

  @Column
  private int consistencyKicker;

  @Column
  private float newProjectScore;

  @Column
  private float daScore;

  @Column
  private float accountGovernanceScore;

  @Column
  private String qualityRating;

  @Column
  private String internalRating;

  @Column
  private String dmRating;

  @Column
  private String amRating;

  @Column
  private String hrRating;

  @Column
  private String csatRating;

  @Column
  private float ytdAverageDAScore;

  @Column
  private String month;

  @Column
  private String year;
}
