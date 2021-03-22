package com.emids.da.model;

import lombok.Data;
import lombok.EqualsAndHashCode;

import javax.persistence.Id;
import java.io.Serializable;
import java.util.Date;

@Data
@EqualsAndHashCode(callSuper = false)
public abstract class BaseEntity extends AdditionalProperties
    implements Serializable, Identifiable {

  private static final long serialVersionUID = -3166979840229584750L;

  @Id private Long id;

  private Date created_date;
  private Date updated_date;
  private String created_by;
  private String updated_by;

  BaseEntity() {
    super();
  }
}
