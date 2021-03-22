package com.emids.da.model;

import lombok.Builder;
import lombok.Data;
import lombok.EqualsAndHashCode;

import javax.persistence.Entity;

@Data
@EqualsAndHashCode(callSuper = false)
@Builder
@Entity
public class Account extends BaseEntity {

  private static final long serialVersionUID = -6108868297257569110L;

  private String accountName;
  private String accountCode;
  private String accountDetails; // JSON
}
